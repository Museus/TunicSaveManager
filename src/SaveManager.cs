using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace DeathsDoorSaveManager {
    public partial class SaveManager : Form {
        private string saveFolder, snapshotFolder;
        private readonly string runFileFmt, snapshotNameFmt;
        private bool confirmLoad;

        /// <summary>
        /// Initialize the SaveManager state.
        /// </summary>
        public SaveManager() {
            saveFolder = "";
            snapshotFolder = "";
            confirmLoad = true;

            runFileFmt = "{0}.tunic";
            snapshotNameFmt = "{0}.sav";

            InitializeComponent();

            LoadState();

            if (saveFolder != "" && saveFolder != null)
                lblSaveFolderPath.Text = saveFolder;

            if (snapshotFolder != "" && snapshotFolder != null)
                lblSnapshotFolderPath.Text = snapshotFolder;
        }

        /// <summary>
        /// LinkChangePath_LinkClicked calls ChangeSelectedFolder on the
        /// correct global string and label based on the clicked link.
        /// </summary>
        /// <param name="sender">The clicked (Change) link object</param>
        /// <param name="e">Args passed by the LinkClicked event</param>
        private void LinkChangePath_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            if (sender.Equals(linkChangeSavePath)) {
                ChangeSelectedFolder(ref saveFolder, lblSaveFolderPath);
            } else if (sender.Equals(linkChangeSnapshotPath)) {
                ChangeSelectedFolder(ref snapshotFolder, lblSnapshotFolderPath);
            }
        }

        /// <summary>
        /// LinkOpenFolder_LinkClicked calls OpenSelectedFolder on the correct
        /// folder based on the clicked link.
        /// </summary>
        /// <param name="sender">The clicked (Open) link object</param>
        /// <param name="e">Args passed by the LinkClicked event</param>
        private void LinkOpenFolder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            string targetFolder;
            if (sender.Equals(linkOpenSaveFolder)) {
                targetFolder = saveFolder;
            } else if (sender.Equals(linkOpenSnapshotFolder)) {
                targetFolder = snapshotFolder;
            } else {
                return;
            }

            OpenSelectedFolder(targetFolder);
        }

        /// <summary>
        /// BtnCreateSnapshot_Click creates a snapshot from the currently
        /// selected save folder.
        /// </summary>
        /// <param name="sender">btnCreateSnapshot</param>
        /// <param name="e">EventArgs from the click event</param>
        private void BtnCreateSnapshot_Click(object sender, EventArgs e) {
            string snapshotName = txtNewSnapshot.Text.Trim();
            if (snapshotName == "") {
                MessageBox.Show("Please enter a name for the snapshot.", "Unnamed Snapshot", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IEnumerable<char> invalidChars = from invalidChar in snapshotName.Intersect(Path.GetInvalidFileNameChars()) select invalidChar;
            if (invalidChars.Count() > 0) {
                MessageBox.Show(
                    String.Format("Snapshot name contains invalid characters: {0}", string.Join(" ", invalidChars)),
                    "Invalid Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return;
            }

            if (!FoldersInitialized()) return;

            Dictionary<string, string> paths = GetPaths(snapshotName);

            if (File.Exists(paths["snapshot"])) {
                // If the snapshot is the same, don't bother replacing it.
                if (FileCompare(paths["snapshot"], paths["run"])) return;

                DialogResult overwriteSnapshot = MessageBox.Show(
                    String.Format("A snapshot named {0} already exists. Would you like to overwrite this snapshot?", snapshotName),
                    "Overwrite Snapshot?",
                    MessageBoxButtons.YesNo
                );

                if (overwriteSnapshot != DialogResult.Yes) return;
            }

            string current_save = GetMostRecentSave();
            File.Copy(current_save, paths["snapshot"], true);

            ReloadSnapshots();
        }

        /// <summary>
        /// BtnLoadSnapshot_Click loads the selected snapshot from
        /// the route folder to the save folder, prompting the user
        /// if this will overwrite the current run.
        /// </summary>
        /// <param name="sender">btnLoadSnapshot</param>
        /// <param name="e">EventArgs from the click event</param>
        private void BtnLoadSnapshot_Click(object sender, EventArgs e) {
            string snapshotName = cboxLoadSnapshot.Text.Trim();
            if (snapshotName == "") {
                MessageBox.Show("Please choose a snapshot to load.", "No Snapshot Chosen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!FoldersInitialized())
                return;

            Dictionary<string, string> paths = GetPaths(snapshotName);

            if (File.Exists(paths["snapshot"])) {
                if (confirmLoad && (File.Exists(paths["run"]))) {
                    DialogResult overwriteRun = MessageBox.Show(
                       String.Format("A save has already been created from this snapshot. This will overwrite that save. Are you sure you want to do this?"),
                       "Overwrite Run?",
                       MessageBoxButtons.YesNo
                    );

                    if (overwriteRun != DialogResult.Yes) return;

                    // Once they've confirmed once, don't ask again
                    confirmLoad = false;
                }

                File.Delete(paths["run"]);

                File.Copy(paths["snapshot"], paths["run"], true);
            }
        }

        /// <summary>
        /// BtnDeleteSnapshot_Click deletes the selected snapshot from
        /// the route folder after prompting the user to confirm.
        /// </summary>
        /// <param name="sender">btnDeleteSnapshot</param>
        /// <param name="e">EventArgs from the click event</param>
        private void BtnDeleteSnapshot_Click(object sender, EventArgs e) {
            string snapshotName = cboxLoadSnapshot.Text.Trim();
            if (snapshotName == "") {
                MessageBox.Show("Please choose a snapshot to delete.", "No Snapshot Chosen", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!FoldersInitialized())
                return;

            string snapshotPath = Path.Combine(snapshotFolder, snapshotName + ".hsm");
            if (File.Exists(snapshotPath)) {
                DialogResult deleteSnapshot = MessageBox.Show(
                    String.Format("YOU ARE DELETING {0}. Are you sure you want to do this?", snapshotName),
                    "Delete Snapshot?",
                    MessageBoxButtons.YesNo
                );

                if (deleteSnapshot != DialogResult.Yes) return;
            } else {
                MessageBox.Show("Chosen snapshot does not exist.", "Snapshot Does Not Exist", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            File.Delete(snapshotPath);
            cboxLoadSnapshot.Text = "";
            ReloadSnapshots();
        }

        /// <summary>
        /// CboxLoadSnapshot reloads the snapshot list when cboxLoadSnapshot
        /// is clicked.
        /// </summary>
        /// <param name="sender">cboxLoadSnapshot object</param>
        /// <param name="e">EventArgs from the click event</param>
        private void CboxLoadSnapshot_Click(object sender, EventArgs e) {
            ReloadSnapshots();
        }

        /// <summary>
        /// ReloadSnapshots checks the provided routeFolder for .hsm files and
        /// updates cboxLoadSnapshot with the list of snapshots.
        /// </summary>
        private void ReloadSnapshots() {
            if (snapshotFolder == "") return;

            cboxLoadSnapshot.Items.Clear();
            foreach (string routeFile in Directory.GetFiles(snapshotFolder)) {
                if (Path.GetExtension(routeFile) == ".sav") {
                    cboxLoadSnapshot.Items.Add(Path.GetFileNameWithoutExtension(routeFile));
                }
            }
        }

        /// <summary>
        /// FoldersInitialized checks the global paths to make sure they have been initialized
        /// </summary>
        /// <returns>true if both folders are initialized</returns>
        private bool FoldersInitialized() {
            if (saveFolder == "") {
                MessageBox.Show("Please select a save folder.", "Unknown Save Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (snapshotFolder == "") {
                MessageBox.Show("Please select a snapshot folder.", "Unknown Snapshot Folder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        /// <summary>
        /// GetPaths builds the paths for all relevant save files
        /// </summary>
        /// <returns>Dictionary of strings containing all paths</returns>
        private Dictionary<string, string> GetPaths(string snapshotName) {
            string snapshotFile = String.Format(snapshotNameFmt, snapshotName);
            string runFile = String.Format(runFileFmt, snapshotName);

            Dictionary<string, string> paths = new Dictionary<string, string> {
                ["snapshot"] = Path.Combine(snapshotFolder, snapshotFile),
                ["run"] = Path.Combine(saveFolder, runFile),
            };

            return paths;
        }

        /// <summary>
        /// SaveState writes the Save/Route paths to the settings.conf file.
        /// </summary>
        private void SaveState() {
            string stateFile = Path.Combine(Application.StartupPath, @"settings.conf");
            string tempFile = Path.GetTempFileName();

            Dictionary<string, string> stateSettings = new Dictionary<string, string> {
                ["saveFolder"] = saveFolder,
                ["snapshotFolder"] = snapshotFolder,
            };

            using (var tempWriter = new StreamWriter(tempFile)) {
                foreach (KeyValuePair<string, string> entry in stateSettings) {
                    tempWriter.WriteLine(String.Format("{0}={1}", entry.Key, entry.Value));
                }
            }

            File.Delete(stateFile);
            File.Move(tempFile, stateFile);
        }

        /// <summary>
        /// LoadState reads the settings.conf file to load Save/Route paths.
        /// </summary>
        private void LoadState() {
            string stateFile = Path.Combine(Application.StartupPath, @"settings.conf");
            Dictionary<string, string> stateSettings = new Dictionary<string, string>();

            if (File.Exists(stateFile)) {
                using StreamReader settingsReader = new StreamReader(stateFile);
                string line;
                while ((line = settingsReader.ReadLine()) != null) {
                    string[] setting = line.Split("=");
                    stateSettings[setting[0]] = setting[1];
                }
            }

            stateSettings.TryGetValue("saveFolder", out string tempSaveFolder);
            if (tempSaveFolder != null && tempSaveFolder != "" && Directory.Exists(tempSaveFolder))
                saveFolder = tempSaveFolder;

            stateSettings.TryGetValue("snapshotFolder", out string tempSnapshotFolder);
            if (tempSnapshotFolder != null && tempSnapshotFolder != "" && Directory.Exists(tempSnapshotFolder))
                snapshotFolder = tempSnapshotFolder;
        }

        /// <summary>
        /// ChangeSelectedFolder allows the user to select a folder using
        /// File Explorer, and updates the provided global variable and label.
        /// </summary>
        /// <param name="targetVar">global variable to update</param>
        /// <param name="targetLbl">label to update</param>
        private void ChangeSelectedFolder(ref string targetVar, Label targetLbl) {
            using FolderBrowserDialog folderDialog = new FolderBrowserDialog {
                SelectedPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments)
            };

            if (folderDialog.ShowDialog() == DialogResult.OK) {
                //Get the path of specified file
                targetVar = folderDialog.SelectedPath;
                targetLbl.Text = targetVar;
                SaveState();
            }
        }

        /// <summary>
        /// OpenSelectedFolder opens File Explorer on the provided path.
        /// </summary>
        /// <param name="folderPath">The path to open File Explorer on</param>
        private void OpenSelectedFolder(string folderPath) {
            if (!Directory.Exists(folderPath))
                return;

            ProcessStartInfo startInfo = new ProcessStartInfo {
                Arguments = folderPath,
                FileName = "explorer.exe",
            };

            Process.Start(startInfo);
        }

        /// <summary>
        /// FileCompare accepts two paths as strings, and returns 0 if the
        /// contents are the same.
        /// </summary>
        /// <param name="file1">Path for File 1 as a string</param>
        /// <param name="file2">Path for File 2 as a string</param>
        /// <returns>0 if File 1 and File 2 are the same.</returns>
        private bool FileCompare(string file1, string file2) {
            int file1byte, file2byte;

            // Determine if the same file was referenced two times.
            if (file1 == file2) return true;

            // Open the two files.
            using FileStream fs1 = new FileStream(file1, FileMode.Open);
            using FileStream fs2 = new FileStream(file2, FileMode.Open);

            // If the file sizes are not the same, the files are not the same.
            if (fs1.Length != fs2.Length) return false;

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Return the success of the comparison. "file1byte" is
            // equal to "file2byte" at this point only if the files are
            // the same.
            return ((file1byte - file2byte) == 0);
        }

        /// <summary>
        /// GetMostRecentSave reads the Player Log to find the most recently loaded save.
        /// </summary>
        private string GetMostRecentSave() {
            var regex_search = new Regex(@"\[SaveFile\] Saving logical savefile `new_snapshot` as `.*\\Secret Legend\\SAVES\\(.*.tunic)` to disk");
            string most_recent_save = "";

            if (!Directory.Exists(saveFolder))
                return "";

            var log_file = Path.Combine(saveFolder, "..", "Player.log");
            using (var log_file_pointer = File.Open(log_file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (StreamReader reader = new StreamReader(log_file_pointer)) {
                string line;
                while ((line = reader.ReadLine()) != null) {
                    // Try to match each line against the Regex.
                    Match match = regex_search.Match(line);
                    if (match.Success) {
                        // Write original line and the value.
                        most_recent_save = match.Groups[1].Value;
                    }
                }
            }

            return Path.Combine(saveFolder, most_recent_save);
        }
    }
}