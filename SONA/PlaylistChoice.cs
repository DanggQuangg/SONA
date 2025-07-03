using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SONA
{
    public partial class PlaylistChoice : UserControl
    {
        string idPlaylist;
        string idSong;
        bool check = false;
        ListenMusic listenMusicForm;
        public PlaylistChoice(Home h, string id_playlist, string playlistName, string id_song)
        {
            InitializeComponent();
            lbPlaylistName.Text = playlistName;
            idPlaylist = id_playlist;
            idSong = id_song;
            btnAdd.Click += btnAdd_Click_ThemBaiHat;
            Load();
        }
        public PlaylistChoice(ListenMusic l)
        {
            InitializeComponent();
            lbPlaylistName.Text = "Tạo Playlist mới";
            btnAdd.Click += btnAdd_Click_ThemPlaylist;
            listenMusicForm = l;
        }
        private void Load()
        {
            try
            {
                using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                using (NetworkStream stream = client.GetStream())
                using (BinaryWriter writer = new BinaryWriter(stream))
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    writer.Write("checkSongInPlaylist");
                    writer.Write(int.Parse(idPlaylist));
                    writer.Write(int.Parse(idSong));
                    string response = reader.ReadString();
                    if (response == "EXISTS")
                    {
                        btnAdd.Image = Properties.Resources.Checked;
                        check = true; // Đánh dấu là đã thêm bài hát vào playlist
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error connecting to server: " + ex.Message);
            }
        }

        private void btnAdd_Click_ThemBaiHat(object sender, EventArgs e)
        {
            if (check)
            {
                try
                {
                    using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        writer.Write("deleteSongFromPlaylist");
                        writer.Write(idPlaylist);
                        writer.Write(idSong);
                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            btnAdd.Image = Properties.Resources.add_circle; // Cập nhật hình ảnh nút bấm
                            check = false; // Đánh dấu là đã thêm bài hát vào playlist
                        }
                        else
                        {
                            MessageBox.Show("Error adding song to playlist: " + response);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to server: " + ex.Message);
                }
            }
            else
            {
                try
                {
                    using (TcpClient client = new TcpClient(IPAddressServer.serverIP, 5000))
                    using (NetworkStream stream = client.GetStream())
                    using (BinaryWriter writer = new BinaryWriter(stream))
                    using (BinaryReader reader = new BinaryReader(stream))
                    {
                        writer.Write("insertSongToPlaylist");
                        writer.Write(idPlaylist);
                        writer.Write(idSong);
                        string response = reader.ReadString();
                        if (response == "OK")
                        {
                            btnAdd.Image = Properties.Resources.Checked; // Cập nhật hình ảnh nút bấm
                            check = true; // Đánh dấu là đã thêm bài hát vào playlist
                        }
                        else
                        {
                            MessageBox.Show("Error adding song to playlist: " + response);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error connecting to server: " + ex.Message);
                }
            }
        }
        private void btnAdd_Click_ThemPlaylist(object sender, EventArgs e)
        {
            listenMusicForm.pnPlaylistName.Visible = true;
        }
    }
}
