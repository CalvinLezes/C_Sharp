namespace C_Sharp;

interface IHall
{
    public List<Contender> Visited { get; }
    public void LoadContenders();
    public Contender GetNextContender();
    public bool IsEmpty();
}