using System;

namespace Items
{
    public interface IIdentity
    {
        Guid   Guid { get; }
        string Id   { get; }
    }

    public interface IInfo
    {
        string Name        { get; }
        string Description { get; }
    }

    public interface IWeapon
    {
        float Damage { get; }
    }
}