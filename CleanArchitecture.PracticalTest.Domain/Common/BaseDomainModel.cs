namespace CleanArchitecture.PracticalTest.Domain.Common;

public enum EntityStatusFilter
{
    OnlyActive,
    OnlyInactive,
    All
}

public abstract class BaseDomainModel
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public Guid CreatedBy { get; set; } = Guid.Empty;
    public DateTime? UpdatedAt { get; set; } = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc);
    public Guid? UpdatedBy { get; set; }
    public bool IsActive { get; set; } = true;
}