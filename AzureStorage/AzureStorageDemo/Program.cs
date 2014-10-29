using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;


namespace AzureStorageDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=http;AccountName=blobeg;AccountKey=DXbO0moBv1DY8AmeBXmfjBOtHjHUzIpNBgqYhTqOcrTD04fym2N3x+L2xVd7NNC8+SpvuLr5r0X6RwWBz4GZJg==");
            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("azurecontainer");
            container.CreateIfNotExists();
            container.SetPermissions(
            new BlobContainerPermissions
            {
                PublicAccess =
                BlobContainerPublicAccessType.Blob
             });

           
            CloudBlockBlob blob = container.GetBlockBlobReference("test.jpg");
            using (var fileStream = System.IO.File.OpenRead(@"C:\Users\divya-mang\Pictures\CSS Pictures\test.jpg"))
            {
                blob.UploadFromStream(fileStream);
            } 
            
            Console.WriteLine("File successfully uploaded at " + blob.Uri);
        }
    }
}

  
