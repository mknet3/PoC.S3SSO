using System.Net;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;

var bucketName = args[0];
var region = args[1];
var key = args[2];

var client = new AmazonS3Client(new AmazonS3Config
{
    RegionEndpoint = RegionEndpoint.GetBySystemName(region)
});

using var response = await client.GetObjectAsync(new GetObjectRequest
{
    BucketName = bucketName,
    Key = key
});

if (response.HttpStatusCode == HttpStatusCode.OK)
{
    using var reader = new StreamReader(response.ResponseStream);
    Console.WriteLine(await reader.ReadToEndAsync());
}