using SONA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class Playlist : UserControl
    {
        private Home h;
        private string idPlaylist, namePlaylist, picturePlaylist;
        private List<string> songIds;

        public Playlist(Home h, string idPlaylist, string namePlaylist, string picturePlaylist)
        {
            this.h = h;
            this.idPlaylist = idPlaylist;
            this.namePlaylist = namePlaylist;
            this.picturePlaylist = picturePlaylist;
            songIds = new List<string>();

            InitializeComponent();
            getIdSongFromPlaylist();
            
            AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
            autoSource.AddRange(h.songNames.ToArray());
            txtSearch.AutoCompleteCustomSource = autoSource;
        }

        private void getIdAllSong()
        {
            try
            {
                flpListSong.Controls.Clear();

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIDSong");

                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        int songCount = reader.ReadInt32();
                        for (int i = 0; i < songCount; i++)
                        {
                            string id_song = reader.ReadString();
                            songIds.Add(id_song);
                        }
                        foreach (var songId in songIds)
                        {
                            SongChoice songChoice = new SongChoice(h, idPlaylist, songId);
                            flpListSong.Controls.Add(songChoice);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private void getIdSongFromPlaylist()
        {
            try
            {
                flpSongs.Controls.Clear();

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIdSongFromPlaylist");
                    writer.Write(idPlaylist);
                    
                    string response = reader.ReadString();
                    if (response == "OK")
                    {
                        int count = reader.ReadInt32();
                        for (int i = 0; i < count; i++)
                        {
                            string id_song = reader.ReadString();
                            songIds.Add(id_song);
                        }
                        foreach (var songId in songIds)
                        {
                            SongPlaylist songPlaylist = new SongPlaylist(h, songId, idPlaylist, songIds);
                            flpSongs.Controls.Add(songPlaylist);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private async void Playlist_Load(object sender, EventArgs e)
        {
            lblNamePlaylist.Text = namePlaylist;
            lblNameUser.Text = User.emailUser;

            try
            {
                if (!string.IsNullOrEmpty(picturePlaylist))
                {
                    using (var htppClient = new HttpClient())
                    {
                        var imageData = await htppClient.GetByteArrayAsync(picturePlaylist);
                        using (var ms = new MemoryStream(imageData))
                        {
                            pbPicturePlaylist.BackgroundImage = Image.FromStream(ms);
                        }
                    }
                }
                else
                {
                    pbPicturePlaylist.BackgroundImage = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading playlist image: " + ex.Message);
                pbPicturePlaylist.BackgroundImage = null;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string searchText = txtSearch.Text;
                flpListSong.Controls.Clear();

                try
                {
                    flpListSong.Controls.Clear();

                    using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        writer.Write("getIDSearchSong");
                        writer.Write(searchText);

                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            int songCount = reader.ReadInt32();
                            for (int i = 0; i < songCount; i++)
                            {
                                string id_song = reader.ReadString();
                                songIds.Add(id_song);
                            }
                            foreach (var songId in songIds)
                            {
                                SongChoice songChoice = new SongChoice(h, idPlaylist, songId);
                                flpListSong.Controls.Add(songChoice);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to server: " + ex.Message);
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            pnAddSong.Visible = true;
            getIdAllSong();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            pnAddSong.Visible = false;
            getIdSongFromPlaylist();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnAddSong.Visible = false;
        }
    }
}
