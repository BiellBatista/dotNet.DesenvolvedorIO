﻿using NerdStore.Core.Messages;

namespace NerdStore.Core.DomainObjects;

public abstract class Entity
{
    private List<Event> _notificacoes;

    public IReadOnlyCollection<Event> Notificacoes => _notificacoes?.AsReadOnly();

    public Guid Id { get; set; }

    protected Entity() => Id = Guid.NewGuid();

    public void AdicionarEvento(Event evento)
    {
        _notificacoes ??= new List<Event>();
        _notificacoes.Add(evento);
    }

    public void RemoverEvento(Event evento) => _notificacoes?.Remove(evento);

    public void LimparEventos() => _notificacoes?.Clear();

    public override bool Equals(object obj)
    {
        var compareTo = obj as Entity;

        if (ReferenceEquals(this, compareTo)) return true;
        if (ReferenceEquals(null, compareTo)) return false;

        return Id.Equals(compareTo.Id);
    }

    public static bool operator ==(Entity a, Entity b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null)) return true;
        if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b) => !(a == b);

    public override int GetHashCode() => (GetType().GetHashCode() * 907) + Id.GetHashCode();

    public override string ToString() => $"{GetType().Name} [Id={Id}]";

    public virtual bool IsValid() => throw new NotImplementedException();
}