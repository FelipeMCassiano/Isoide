using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Isoide.Domain.Repositories;
using Isoide.Domain.Services;
using Isoide.Infrastructure.DataAccess;
using Isoide.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Isoide.Infrastructure;

public static class DependencyInjectionExtension
{
	public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		AddDb(services, configuration);
		AddBlobStorage(services, configuration);
	}

	private static void AddDb(IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<IsoideDatabaseSettings>(configuration.GetSection("IsoideDatabase"));
		services.AddSingleton<IQrCodeRepository, MongoDbRepository>();
	}

	private static void AddBlobStorage(IServiceCollection services, IConfiguration configuration)
	{
		 var accessKey = configuration.GetValue<string>("Settings:Aws:AccessKey")!;
		 var secretKey = configuration.GetValue<string>("Settings:Aws:SecretKey")!;
		 var credentials = new BasicAWSCredentials(accessKey, secretKey);
		
		var s3Client = new AmazonS3Client(credentials,new AmazonS3Config()
		{
			ServiceURL = "https://t3.storage.dev",
			ForcePathStyle = false,
		});
		
		var bucketName = configuration.GetValue<string>("Settings:Aws:BucketName")!;
		
		services.AddScoped<IBlobStorageService, AwsS3>(_ => new AwsS3(s3Client, bucketName));
	}
}