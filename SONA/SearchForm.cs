using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net.Sockets;

namespace SONA
{
    public partial class SearchForm : UserControl
    {
        private Home h;
        private string idUser;
        private List<string> songIds = new List<string>();
        private List<string> artistIds = new List<string>();
        string searchText;

        public SearchForm(Home h, string idUser, string searchText)
        {
            InitializeComponent();
            this.h = h;
            this.idUser = idUser;
            this.searchText = searchText;
        }
        private void SearchSong()
        {
            flpResult.Controls.Clear();
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
                    int songCount = reader.ReadInt32(); // Đọc số lượng bài hát

                    for (int i = 0; i < songCount; i++)
                    {
                        string id_song = reader.ReadString();
                        songIds.Add(id_song);

                    }
                    for (int i = 0; i < songCount; i++)
                    {
                        SongForm songForm = new SongForm(h, songIds[i], idUser, songIds);
                        flpResult.Controls.Add(songForm);
                    }
                }
                else
                {
                    
                }
            }
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
            SearchSong();
        }

        private void btnSongs_Click(object sender, EventArgs e)
        {
            SearchSong();
        }

        private void btnArtists_Click(object sender, EventArgs e)
        {
            try
            {
                flpResult.Controls.Clear();

                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("getIDSearchArtis");
                    writer.Write(searchText);
                    string response = reader.ReadString();

                    if (response == "OK")
                    {
                        int singerCount = reader.ReadInt32();

                        for (int i = 0; i < singerCount; i++)
                        {
                            string id_singer = reader.ReadString();
                            artistIds.Add(id_singer);
                            ArtistForm artistForm = new ArtistForm(h, id_singer, idUser);
                            flpResult.Controls.Add(artistForm);
                        }
                    }
                    else
                    {
                        MessageBox.Show(response); // Hiển thị lỗi từ server
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }
    }
}