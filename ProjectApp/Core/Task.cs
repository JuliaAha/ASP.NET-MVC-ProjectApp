namespace ProjectApp.Core;

public class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    
    private DateTime _lastUpdated;
    public DateTime LastUpdated  { get => _lastUpdated; }
    private Status _status;

    public Status Status
    {
        get => _status;
        set
        {
            if (_status == Status.DONE &&  value != Status.DONE)
                throw new InvalidOperationException("Cannot change status when the task is done");
            _status = value;
            _lastUpdated = DateTime.Now;
        }
    }

    public Task(int id, string description)
    {
        Id = id;
        Description = description;
        _lastUpdated = DateTime.Now;
    }
}