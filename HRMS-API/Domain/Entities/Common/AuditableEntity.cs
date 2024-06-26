﻿namespace Domain.Entities.Common;
public abstract class AuditableEntity<TId>
{
    public AuditableEntity()
    {
        LastModified = DateTime.UtcNow;
        Created = DateTime.UtcNow;
    }
    public virtual TId Id { get; protected set; }
    public DateTime? Created { get; set; } = DateTime.UtcNow;
    public DateTime? LastModified { get; set; }
    public DateTime? Deleted { get; set; }
    public string? CreatedBy { get; set; } = string.Empty;
    public string? LastModifiedBy { get; set; }
    public string? DeletedBy { get; set; }

    int? _requestedHashCode;

    public bool IsTransient()
    {
        return Id!.Equals(default(TId));
    }

    public override bool Equals(object obj)
    {
        if (obj == null || obj is not AuditableEntity<TId>)
            return false;

        if (ReferenceEquals(this, obj))
            return true;

        if (GetType() != obj.GetType())
            return false;

        var item = (AuditableEntity<TId>)obj;

        if (item.IsTransient() || IsTransient())
            return false;
        else
            return item == this;
    }

    public override int GetHashCode()
    {
        if (!IsTransient())
        {
            if (!_requestedHashCode.HasValue)
                _requestedHashCode = Id!.GetHashCode() ^ 31;

            return _requestedHashCode.Value;
        }
        else
            return base.GetHashCode();
    }
}