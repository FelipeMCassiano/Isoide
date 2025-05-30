using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Isoide.Domain.Entities;

public class QrCode
{
	[BsonId]
	[BsonGuidRepresentation(GuidRepresentation.Standard)]
	public Guid Id { get; set; }
	public string Url { get; set; } = string.Empty;
}