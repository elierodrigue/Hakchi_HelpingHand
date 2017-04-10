using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hakchi_HelpingHand
{
    static class AppTypeCollection
    {
        //public delegate NesMiniApplication 

        public class AppInfo
        {
            public Type Class;
            public string[] Extensions;
            public string[] DefaultApps;
            public char Prefix;
        }

        public static AppInfo[] ApplicationTypes = new AppInfo[]
        {
             new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.NesGame),
                Extensions = new string[] {".nes", ".unf", ".unif"},
                DefaultApps = new string[] {"/usr/bin/clover-kachikachi","/bin/clover-kachikachi","/bin/clover-kachikachi-wr"},
                Prefix = 'H'
            },
        /*    new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.FdsGame),
                Extensions = new string[] {".fds"},
                DefaultApps = new string[] {"/bin/nes"},
                Prefix = 'D'

            },*/
            new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.NesUGame),
                Extensions = new string[] {".nes", ".unf", ".unif"},
                DefaultApps = new string[] {"/bin/nes"},
                Prefix = 'H'
            },
            new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.SnesGame),
                Extensions = new string[] { ".sfc", ".smc" },
                DefaultApps = new string[] {"/bin/snes"},
                Prefix = 'U'
            },
            new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.N64Game),
                Extensions = new string[] { ".n64", ".z64", ".v64" },
                DefaultApps = new string[] {"/bin/n64"},
                Prefix = '6'
            },
            new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.SmsGame),
                Extensions = new string[] { ".sms" },
                DefaultApps = new string[] {"/bin/sms"},
                Prefix = 'M'
            },

            new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.GenesisGame),
                Extensions = new string[] { ".gen", ".md", ".smd" },
                DefaultApps = new string[] {"/bin/md"},
                Prefix = 'G'
            },
            new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.Sega32XGame),
                Extensions = new string[] { ".32x" },
                DefaultApps = new string[] {"/bin/32x"},
                Prefix = '3'
            },
            new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.GbGame),
                Extensions = new string[] { ".gb" },
                DefaultApps = new string[] {"/bin/gb"},
                Prefix = 'B'
            },
            new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.GbcGame),
                Extensions = new string[] {".gbc"},
                DefaultApps = new string[] {"/bin/gbc"},
                Prefix = 'C'
            },
            new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.GbaGame),
                Extensions = new string[] {".gba"},
                DefaultApps = new string[] {"/bin/gba"},
                Prefix = 'A'
            },
            new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.PceGame),
                Extensions = new string[] {".pce"},
                DefaultApps = new string[] {"/bin/pce"},
                Prefix = 'E'
            },
            new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.GameGearGame),
                Extensions = new string[] {".gg"},
                DefaultApps = new string[] {"/bin/gg"},
                Prefix = 'R'
            },
            new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.Atari2600Game),
                Extensions = new string[] {".a26"},
                DefaultApps = new string[] {"/bin/a26"},
                Prefix = 'T'
            },
            new AppInfo
            {
                Class = typeof(com.clusterrr.hakchi_gui.ArcadeGame),
                Extensions = new string[] {},
                DefaultApps = new string[] {"/bin/fba", "/bin/mame", "/bin/cps2", "/bin/neogeo" },
                Prefix = 'X'
            },
        };

        public static AppInfo GetAppByExtension(string extension)
        {
            foreach (var app in ApplicationTypes)
                if (Array.IndexOf(app.Extensions, extension) >= 0)
                    return app;
            return null;
        }

        public static AppInfo GetAppByExec(string exec)
        {
            foreach (var app in ApplicationTypes)
                foreach (var cmd in app.DefaultApps)
                    if (exec.StartsWith(cmd + " "))
                        return app;
            return null;
        }
        public static AppInfo GetAppByType(Type theType)
        {
            foreach (var app in ApplicationTypes)
                if (app.Class == theType)
                    return app;

            return null;
        }
    }
}
