/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Text; 
using System.Threading.Tasks;

namespace CommunicationWinRT
{
    [Windows.Foundation.Metadata.AllowForWeb]
    public sealed class CommunicationWinRT
    {
        public CommunicationWinRT() 
        {
        }
        public String GetValue()
        {
            return "From my WinRT component Yo!";
        }
    }
}
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Notifications;
using Windows.Data.Xml.Dom;
using Windows.Media.Capture;
using Windows.Storage;
using Windows.Storage.AccessCache;
using Windows.Storage.Streams;
using Windows.Foundation;

namespace CommunicationWinRT
{
    [Windows.Foundation.Metadata.AllowForWeb]
    public sealed class cameraWinRT
    {
        public cameraWinRT()
        {
        }

        //public IAsyncOperation<string> CapturePicture()
        //{
        //    return getStringHelper().AsAsyncOperation();
            
        //}

        //private async Task<string> getStringHelper()
        //{
        //    var dialog = new CameraCaptureUI();
        //    var file = await dialog.CaptureFileAsync(CameraCaptureUIMode.Photo);
        //    // Do something useful w/ the file
        //    byte[] imageStream = await ToByteArrayAsync(file);
        //    string base64String = Convert.ToBase64String(imageStream);
        //    return base64String;
            
        //} 

        
        private static async Task<byte[]> ToByteArrayAsync(StorageFile file)
        {
            using (IRandomAccessStream stream = await file.OpenReadAsync())
            {
                using (DataReader reader = new DataReader(stream.GetInputStreamAt(0)))
                {
                    await reader.LoadAsync((uint)stream.Size);
                    byte[] Bytes = new byte[stream.Size];
                    reader.ReadBytes(Bytes);
                    return Bytes;
                }
            }
        }
          

    }


    
    
    [Windows.Foundation.Metadata.AllowForWeb]
    public sealed class CommunicationWinRT
    {
        public CommunicationWinRT()
        {
        }

        public async void toastMessage(String message, int delay)
        {
            ToastTemplateType toastTemplate = ToastTemplateType.ToastImageAndText01;
            XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(toastTemplate);

            XmlNodeList toastTextElements = toastXml.GetElementsByTagName("text");
            toastTextElements[0].AppendChild(toastXml.CreateTextNode(message));

            XmlNodeList toastImageAttributes = toastXml.GetElementsByTagName("image");
            //((XmlElement)toastImageAttributes[0]).SetAttribute("src", "http://microsoft-chat.com/wp-content/uploads/2014/05/Microsoft_0-300x168.jpg");
            //((XmlElement)toastImageAttributes[0]).SetAttribute("src", "https://raw.githubusercontent.com/seksenov/grouppost/master/images/AddNote.png");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("src", "https://raw.githubusercontent.com/seksenov/grouppost/master/images/logo.png");
            ((XmlElement)toastImageAttributes[0]).SetAttribute("alt", "red graphic");

            IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            ((XmlElement)toastNode).SetAttribute("duration", "short");

            XmlElement audio = toastXml.CreateElement("audio");
            audio.SetAttribute("src", "ms-winsoundevent:Notification.IM");
            toastNode.AppendChild(audio);

            ((XmlElement)toastNode).SetAttribute("launch", "{\"type\":\"toast\",\"param1\":\"12345\",\"param2\":\"67890\"}");

            ToastNotification toast = new ToastNotification(toastXml);

            await Task.Delay(delay);
            ToastNotificationManager.CreateToastNotifier().Show(toast);
        }

      
    }
}