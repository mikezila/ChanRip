using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace ChanRip
{
    public partial class BrowserForm : Form
    {
        private string board = "h";
        const string imageNotFound = "http://s.4cdn.org/image/filedeleted.gif";
        private const int minimumImages = 10;

        public BrowserForm()
        {
            InitializeComponent();
            ParseCatalog(board);
        }

        private void ParseCatalog(string board)
        {
            string catalogJSON;
            using (var client = new WebClient())
            {
                catalogJSON = client.DownloadString("http://a.4cdn.org/" + board + "/catalog.json");
            }

            JArray catalog = JArray.Parse(catalogJSON);
            List<JToken> threads = new List<JToken>();

            foreach (JToken item in catalog)
            {
                threads.AddRange(item["threads"].Children().ToList());
            }

            List<Thread> threadList = new List<Thread>();
            foreach (JToken thread in threads)
            {
                Thread item = JsonConvert.DeserializeObject<Thread>(thread.ToString());
                item.board = board;
                if (item.images < minimumImages)
                {
                    continue;
                }
                threadList.Add(item);
            }
            threadList.Sort();
            threadListbox.DataSource = threadList;
        }

        List<Post> postList;
        private void threadListbox_SelectedValueChanged(object sender, EventArgs e)
        {
            Thread thread = (Thread)threadListbox.SelectedItem;

            string threadJSON;
            postList = new List<Post>();
            using (var client = new WebClient())
            {
                threadJSON = client.DownloadString("http://a.4cdn.org/" + board + "/thread/" + thread.no.ToString() + ".json");
            }
            JObject postData = JObject.Parse(threadJSON);

            foreach (var post in postData.First.First.Children())
            {
                try
                {
                    Post item = new Post();
                    item.tim = post["tim"].Value<string>();
                    item.ext = post["ext"].Value<string>();
                    item.vanityFilename = post["filename"].Value<string>();
                    item.board = board;
                    postList.Add(item);
                }
                catch (Exception)
                {
                    continue;
                }
            }

            postListBox.DataSource = postList;
        }

        private void fullButton_Click(object sender, EventArgs e)
        {
            try
            {
                Post post = (Post)postListBox.SelectedItem;
                if (post.ext == ".webm")
                    return;
                imageBox.Load(post.ImageURL);
            }
            catch (Exception)
            {
                imageBox.Load(imageNotFound);
            }
        }

        private void imagesListbox_SelectedValueChanged(object sender, EventArgs e)
        {
            Post post = (Post)postListBox.SelectedItem;
            try
            {
                if (loadFullItemsMenuItem.Checked)
                    imageBox.Load(post.ImageURL);
                else
                    imageBox.Load(post.ThumbURL);

            }
            catch (Exception)
            {
                imageBox.Load(imageNotFound);
            }
        }

        private void ripButton_Click(object sender, EventArgs e)
        {
            DisableButtons();
            Thread thread = (Thread)threadListbox.SelectedItem;
            ripWorker.RunWorkerAsync(thread);
        }

        private void ripWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread thread = (Thread)e.Argument;
            Directory.CreateDirectory(thread.semantic_url);
            BinaryFormatter bin = new BinaryFormatter();

            int count = 0;

            try
            {
                using (var file = File.Open(thread.semantic_url + "/chanripmeta", FileMode.Create))
                {
                    bin.Serialize(file, thread);
                }
            }
            catch (Exception)
            {
                throw;
            }

            using (var client = new WebClient())
            {
                foreach (var post in postList)
                {
                    if (!File.Exists(thread.semantic_url + "/" + post.UniqueFileName))
                        client.DownloadFile(post.ImageURL, (thread.semantic_url + "/" + post.UniqueFileName));
                    count++;
                    decimal per = ((decimal)count / postList.Count) * 100;
                    ripWorker.ReportProgress((int)per);
                }
            }
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            DisableButtons();
            updateWorker.RunWorkerAsync();
        }

        private void DisableButtons()
        {
            updateButton.Enabled = false;
            ripButton.Enabled = false;
        }

        private void EnableButtons()
        {
            updateButton.Enabled = true;
            ripButton.Enabled = true;
        }

        private void ripWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableButtons();
        }

        private void updateWorker_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar.Value = e.ProgressPercentage;
        }

        private void updateWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            EnableButtons();
        }
    }
}
