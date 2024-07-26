namespace RCommon.EventHandling.Subscribers
{
    public interface ISubscriberFactory
    {
        ISubscriber<TEvent> Resolve<TEvent>(string name);
        TSubscriber Resolve<TSubscriber, TEvent>(string name) where TSubscriber : ISubscriber<TEvent>;
    }
}