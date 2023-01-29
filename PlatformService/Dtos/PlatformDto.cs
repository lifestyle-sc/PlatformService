namespace PlatformService.Dtos
{
    public record PlatformDto
    {
        public Guid Id { get; init; }
        public string? Name { get; init; }
        public string? Publisher { get; init; }
        public string? Cost { get; init; }
    }
}
