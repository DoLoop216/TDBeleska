using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Notes.Models
{
    public class NoteModel
    {
        public static string Folder = "Notes";

        public int UserID { get; set; }
        public string Text { get; set; }

        public NoteModel(int UserID)
        {
            this.UserID = UserID;
            if (File.Exists(Path.Combine(Folder, UserID.ToString())))
                this.Text = File.ReadAllText(Path.Combine(Folder, UserID.ToString()));
        }

        public void Update()
        {
            File.WriteAllText(Path.Combine(Folder, UserID.ToString()), this.Text);
        }

    }
}
