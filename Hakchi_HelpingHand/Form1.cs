using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using com.clusterrr.hakchi_gui;
namespace Hakchi_HelpingHand
{
    public partial class Form1 : Form
    {
#if DEBUG
        public static string runningFolder = "c:\\hakchi214\\hakchi2";

#else
        public static string runningFolder = Path.GetDirectoryName(Application.ExecutablePath);
#endif

        public Form1()
        {
            InitializeComponent();
            compressWorker.DoWork += CompressWorker_DoWork;
            compressWorker.RunWorkerCompleted += CompressWorker_RunWorkerCompleted;
            distinguish.DoWork += Distinguish_DoWork;
            distinguish.RunWorkerCompleted += Distinguish_RunWorkerCompleted;
            cleanup.DoWork += Cleanup_DoWork;
            cleanup.RunWorkerCompleted += Cleanup_RunWorkerCompleted;
            fixRom.DoWork += FixRom_DoWork;
            fixRom.RunWorkerCompleted += FixRom_RunWorkerCompleted;
   
        }


        private void FixRom_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AddLog("Fix rom done", null);
            Enable();
        }
        public static NesMiniApplication FromDirectory(string path, bool ignoreEmptyConfig = false)
        {
            var files = Directory.GetFiles(path, "*.desktop", SearchOption.TopDirectoryOnly);
            if (files.Length == 0)
                throw new FileNotFoundException("Invalid app folder");
            var config = File.ReadAllLines(files[0]);
            string exec = "";
            foreach (var line in config)
            {
                if (line.StartsWith("Exec="))
                {
                    exec = line;
                    break;
                   
                 
                }
            }

            string command = exec.Substring(5);

            var app = AppTypeCollection.GetAppByExec(command);
            if (app != null)
            {
                var constructor = app.Class.GetConstructor(new Type[] { typeof(string), typeof(bool) });
                return (NesMiniApplication)constructor.Invoke(new object[] { path, ignoreEmptyConfig });
            }
            else
            {
                return null;
            }
       
        }
        private void FixRom_DoWork(object sender, DoWorkEventArgs e)
        {
            var games = new List<NesMiniApplication>();


            var gameDirs = Directory.GetDirectories(Path.Combine(runningFolder, "games"));
            AddLog("Cleanup");
            foreach (var gameDir in gameDirs)
            {
               // try
                {
                    // Removing empty directories without errors
                    try
                    {
                        var game = FromDirectory(gameDir);
                        string romfile = GetRomFile(game);
                        if(romfile != "")
                        {
                            Console.Write("");
                            string originalExtension = romfile.Substring(romfile.IndexOf("."));
                            string originalFileName = romfile.Substring(0, romfile.IndexOf("."));
                            string newFileName = game.Code;
                            if(newFileName != originalFileName)
                            {
                                string originalFullPath = System.IO.Path.Combine(game.GamePath, originalFileName + originalExtension);
                                string finalFullPath = System.IO.Path.Combine(game.GamePath, newFileName + originalExtension);
                                System.IO.File.Move(originalFullPath, finalFullPath);
                                game.Command = game.Command.Replace(originalFileName, newFileName);
                                AddLog("Fixed rom " + game.Name);
                                game.Save();
                            }
                        
                            if(game.Command.StartsWith("/bin/nes") || game.Command.StartsWith("/bin/clover-kachikachi"))
                            {
                                string shouldBeCommand = "/bin/nes /usr/share/games/nes/kachikachi/" + game.Code + "/" + game.Code + ".nes.7z " + NesParam;
                                if(game.Command != shouldBeCommand)
                                {
                                    game.Command = shouldBeCommand;
                                    game.Save();
                                }
                            }
                        }

                    }
                    catch (FileNotFoundException ex) // Remove bad directories if any
                    {

                        Directory.Delete(gameDir, true);
                    }
                }
               /* catch (Exception ex)
                {

                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }*/
            }
            AddLog("Done loading game list", null);
        }

        private void Cleanup_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AddLog("Cleanup sequence done", null);
            Enable();
        }

        private void Cleanup_DoWork(object sender, DoWorkEventArgs e)
        {
            var games = new List<NesMiniApplication>();
        

            var gameDirs = Directory.GetDirectories(Path.Combine(runningFolder, "games"));
            AddLog("Cleanup");
            foreach (var gameDir in gameDirs)
            {
                try
                {
                    // Removing empty directories without errors
                    try
                    {
                        var game = NesMiniApplication.FromDirectory(gameDir);
                        string ogName = game.Name;
                        bool dirty = false;
                        if (game.Name.Trim() != game.Name)
                        {
                            game.Name = game.Name.Trim();
                            dirty = true;
                        }
                        if (game.Name.EndsWith("-"))
                        {
                            game.Name = game.Name.Substring(0, game.Name.Length - 1);

                            dirty = true;
                        }
                        if(game.Name.Contains("_"))
                        {
                            dirty = true;
                            game.Name = game.Name.Replace("_", " ");
                        }
                        while(game.Name.Contains("  "))
                        {
                            dirty = true;
                            game.Name = game.Name.Replace("  ", " ");
                        }
                        if(game.Name.Trim() != game.Name)
                        {
                            game.Name = game.Name.Trim();
                            dirty = true;
                        }
                        
                        if(dirty)
                        {
                            AddLog("Renamed " + ogName + " to " + game.Name);
                            game.Save();
                        }

                    }
                    catch (FileNotFoundException ex) // Remove bad directories if any
                    {

                        Directory.Delete(gameDir, true);
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
            }
            AddLog("Done loading game list", null);
           
        }

        private void Distinguish_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AddLog("Distinguish sequence done", null);
            Enable();
        }

        private void Distinguish_DoWork(object sender, DoWorkEventArgs e)
        {
            var games = new List<NesMiniApplication>();
            Dictionary<string, List<NesMiniApplication>> sortedGames = new Dictionary<string, List<NesMiniApplication>>();
            
            var gameDirs = Directory.GetDirectories(Path.Combine(runningFolder, "games"));
            AddLog("Loading game list");
            foreach (var gameDir in gameDirs)
            {
                try
                {
                    // Removing empty directories without errors
                    try
                    {
                        var game = NesMiniApplication.FromDirectory(gameDir);
                        if(!sortedGames.ContainsKey(game.Name + " | " + game.GoogleSuffix))
                        {
                            sortedGames.Add(game.Name + " | " + game.GoogleSuffix, new List<NesMiniApplication>());
                        }
                        sortedGames[game.Name + " | " + game.GoogleSuffix].Add(game);
                        
                        

                    }
                    catch (FileNotFoundException ex) // Remove bad directories if any
                    {

                        Directory.Delete(gameDir, true);
                    }
                }
                catch (Exception ex)
                {
                 
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
            }
            AddLog("Done loading game list", null);
            foreach(string gameName in sortedGames.Keys)
            {
                if(sortedGames[gameName].Count()>1)
                {
                    AddLog(gameName + " have " + sortedGames[gameName].Count());
                    string simmilar = findSimilar(sortedGames[gameName]);
                    if (simmilar != "")
                    {
                        foreach (NesMiniApplication app in sortedGames[gameName])
                        {
                            string f = app.Command.Substring(app.Command.LastIndexOf("/") + 1);
                            string difference = f.Replace(simmilar, "");
                            if (difference.Contains("."))
                            {
                                difference = difference.Substring(0, difference.IndexOf("."));
                            }
                            AddLog("Renaming " + app.Name + " to " + app.Name + " - " + difference);
                            app.Name = app.Name + " - " + difference;
                            app.Save();
                        }
                    }
                }
            }
        }
        private static string findSimilar(List<NesMiniApplication> apps)
        {
            List<string> filenames = new List<string>();
            foreach(NesMiniApplication app in apps)
            {
                string f = app.Command.Substring(app.Command.LastIndexOf("/") + 1);
                filenames.Add(f);
            }
            string simmilar = "";
            for(int x = 0;x<filenames[0].Length;x++)
            {
                bool doIt = true;
                for(int y = 1;y<filenames.Count();y++)
                {
                    if(filenames[y].Length>x)
                    {
                        if(filenames[y][x] == filenames[0][x])
                        {

                        }
                        else
                        {
                            doIt = false;
                            break;
                        }
                    }
                    else
                    {
                        doIt = false;
                        break;
                    }
                }
                if(doIt)
                {
                    simmilar += filenames[0][x];
                }
                else
                {
                    break;
                }
            }
            return simmilar;
        }
       
        private void AddLog(string log)
        {
            AddLog(log, null);
        }
        private void AddLog(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new EventHandler(AddLog), new object[] { sender, e });
            }
            else
            {
                if(this.lstLog.Items.Count == 0)
                {
                    this.lstLog.Items.Add(sender);
                }
                else
                {
                    this.lstLog.Items.Insert(0, sender);
                }
            }
        }
        public void Enable()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            button4.Enabled = true;
            button3.Enabled = true;
       
        }
        public void Disable()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
          
        }
      
        private void CompressWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AddLog("Compression sequence done",null);
            Enable();
        }

        private void CompressWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            AddLog("Start compression sequence",null);

            var games = new List<NesMiniApplication>();
            var gameDirs = Directory.GetDirectories(Path.Combine(runningFolder, "games"));
            AddLog("Loading game list");
            foreach (var gameDir in gameDirs)
            {
                try
                {
                    // Removing empty directories without errors
                    try
                    {
                        var game = NesMiniApplication.FromDirectory(gameDir);
                        if ((System.IO.Directory.GetFiles(game.GamePath, "*.7z").Length > 0))
                        {

                        }
                        else
                        {
                            AddLog(game.Name + " is not compressed");
                            games.Add(game);
                        }
                          
                    }
                    catch (FileNotFoundException ex) // Remove bad directories if any
                    {
                      
                        Directory.Delete(gameDir, true);
                    }
                }
                catch (Exception ex)
                {
                  
                    MessageBox.Show(this, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
            }
            AddLog("Done loading game list",null);

            AddLog(games.Count().ToString() + " games to compress");
            foreach(NesMiniApplication nm in games)
            {
                System.Collections.Generic.List<string> ext = new System.Collections.Generic.List<string>(AppTypeCollection.GetAppByType(nm.GetType()).Extensions);
                foreach (string f in System.IO.Directory.GetFiles(nm.GamePath))
                {
                    if (ext.Contains(System.IO.Path.GetExtension(f)))
                    {

                        File.WriteAllBytes(f + ".7z", Compress(f));
                        System.IO.File.Delete(f);
                        if(nm.Command.StartsWith("/bin/clover-kachikachi"))
                        {
                            //Replace with new command
                            nm.Command = (f + ".7z").Replace(Path.Combine(runningFolder, "games"), AppTypeCollection.GetAppByType(nm.GetType()).DefaultApps[0] + " /usr/share/games/nes/kachikachi").Replace("\\", "/");
                        }
                        else
                        {
                            nm.Command = nm.Command.Replace(System.IO.Path.GetFileName(f), System.IO.Path.GetFileName(f) + ".7z");
                        }
                        nm.Save();
                    }
                }
            }
            AddLog("Done compressing");

        }
        private static byte[] Compress(string filename)
        {
            SevenZip.SevenZipExtractor.SetLibraryPath(Path.Combine(runningFolder, IntPtr.Size == 8 ? @"tools\7z64.dll" : @"tools\7z.dll"));
            var arch = new MemoryStream();
            var compressor = new SevenZip.SevenZipCompressor();
            compressor.CompressionLevel = SevenZip.CompressionLevel.High;
            compressor.CompressFiles(arch, filename);
            arch.Seek(0, SeekOrigin.Begin);
            var result = new byte[arch.Length];
            arch.Read(result, 0, result.Length);
            return result;
        }
        BackgroundWorker compressWorker = new BackgroundWorker();
        BackgroundWorker distinguish = new BackgroundWorker();
        BackgroundWorker cleanup = new BackgroundWorker();
        BackgroundWorker fixRom = new BackgroundWorker();
        BackgroundWorker forceNesCore = new BackgroundWorker();
        private void button1_Click(object sender, EventArgs e)
        {
            Disable();
            SetNesParam();
            compressWorker.RunWorkerAsync();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Disable();
            distinguish.RunWorkerAsync();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Disable();
            cleanup.RunWorkerAsync();
        }
        private string NesParam = "";
       private void SetNesParam()
        {
            NesParam = txtNesParam.Text;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Disable();
            SetNesParam();
            fixRom.RunWorkerAsync();
        }
        public string GetRomFile(NesMiniApplication app)
        {
            System.Collections.Generic.List<string> exts = new System.Collections.Generic.List<string>(AppTypeCollection.GetAppByType(app.GetType()).Extensions);
            List<string> expectedFiles = new List<string>();
            expectedFiles.Add(app.Code + ".desktop");
            expectedFiles.Add(app.Code + ".png");
            expectedFiles.Add(app.Code + "_small.png");

            List<string> possibleRomFiles = new List<string>();
            List<string> zFiles = new List<string>();


            foreach (string f in System.IO.Directory.GetFiles(app.GamePath))
            {
                string fileName = System.IO.Path.GetFileName(f);
                if (!expectedFiles.Contains(fileName))
                {
                    string ext = System.IO.Path.GetExtension(fileName);
                    if (ext == ".7z")
                    {
                        zFiles.Add(fileName);
                    }
                    else
                    {
                        if (!exts.Contains(ext))
                        {

                        }
                        else
                        {
                            possibleRomFiles.Add(fileName);
                        }
                    }
                }
            }
            string tempCommand = app.Command;
            tempCommand = tempCommand.Replace(".nes .7z", ".nes.7z");


            /*Find if of the file is linked in the commande*/
            string foundRom = "";
            foreach (string z in zFiles)
            {
                if (tempCommand.Contains(z))
                {
                    foundRom = z;
                    break;
                }
            }
            if (foundRom == "")
            {
                /*Rom was not found in 7z*/
                foreach (string z in possibleRomFiles)
                {
                    if (tempCommand.Contains(z))
                    {
                        foundRom = z;
                        break;
                    }
                }
            }
            if (foundRom == "")
            {
                //Cant find rom from command line, now analyse files
                if (zFiles.Count >= 1)
                {
                    //Most likely this one
                    foundRom = zFiles[0];
                }
                else
                {
                    if (possibleRomFiles.Count >= 1)
                    {
                        foundRom = possibleRomFiles[0];
                    }

                }

            }
            if (foundRom == "")
            {
                string test = "abc";
            }
            return foundRom;



        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void clovershellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClovershellConsolecs c = new ClovershellConsolecs();
            c.ShowDialog();
         
        }

        private void filebrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloverFileBrowser cfb = new CloverFileBrowser();
            cfb.ShowDialog();
        }

        private void gameBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LiveGameBrowser gb = new LiveGameBrowser();
            gb.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            com.clusterrr.clovershell.ClovershellConnection conn = new com.clusterrr.clovershell.ClovershellConnection() {  Enabled = true };
            if (!conn.IsOnline)
            {
                Application.DoEvents();
                System.Threading.Thread.Sleep(1000);
                Application.DoEvents();
            }
            if(!conn.IsOnline)
            { 
                MessageBox.Show("Nes classic need to be connected");
            }
            else
            {
                AddLog("Downloading chmenu script", null);
                System.IO.MemoryStream ms = new MemoryStream();
                conn.Execute("cat /var/lib/hakchi/rootfs/bin/chmenu", null, ms, null, 15000, false);
                ms.Seek(0, SeekOrigin.Begin);
                System.IO.TextReader rdr = new System.IO.StreamReader(ms);
                string file = rdr.ReadToEnd();
                

                if(!file.Contains("#CLEANSAVEDGAMEFOLDER"))
                {
                    AddLog("Building fixed files", null);
                    file = file.Replace("overmount_games", "#CLEANSAVEDGAMEFOLDER\nfind /var/lib/clover/profiles/0/ -type d -exec rmdir {} \\;\n#ENDCLEANSAVEDGAMEFOLDER\novermount_games");
                    AddLog("Uploading fixed files", null);
                    System.IO.MemoryStream ms2 = new MemoryStream();
                    System.IO.TextWriter wri = new System.IO.StreamWriter(ms2);
                    wri.Write(file);
                    wri.Flush();
                    ms2.Seek(0, SeekOrigin.Begin);
                 
                    string command = "cat > /var/lib/hakchi/rootfs/bin/chmenu";
                    conn.Execute(command, ms2, null, null, 30000, true);
                    wri.Close();
                    AddLog("Done", null);
                   
                }
                else
                {
                    AddLog("Cache fix already in place", null);
                }
                rdr.Close();
                conn.Disconnect();
            }
           
        }
    }
}
