using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Isoide.Domain.Services;

namespace Isoide.Infrastructure.Services;

public class AwsS3 : IBlobStorageService
{
	private readonly IAmazonS3 _client;
	private readonly string _bucketName;

	public AwsS3(IAmazonS3 client, string bucketName)
	{
		_client = client;
		_bucketName = bucketName;
	}

	public async Task UploadFile(MemoryStream memoryStream, Guid id)
	{
		var uploadRequest = new PutObjectRequest()
		{
			BucketName = _bucketName, 
			InputStream = memoryStream,
			Key = id.ToString(),
			ContentType = "application/octet-stream",
			UseChunkEncoding = false
		};
		await _client.PutObjectAsync(uploadRequest);
	}

	public async Task<string> GetFileUrl(Guid id)
	{
		var urlRequest = new GetPreSignedUrlRequest()
		{
			BucketName = _bucketName,
			Key = id.ToString(),
			Expires = DateTime.UtcNow.AddHours(1),
			Verb = HttpVerb.GET
		};
		
		return await _client.GetPreSignedURLAsync(urlRequest);
	}
}