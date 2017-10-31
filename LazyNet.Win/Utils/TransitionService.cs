using System;

namespace Dekart.LazyNet.Win
{
    public interface ISupportTransitions
    {
        void StartTransition(bool forward, object waitParameter);
        void EndTransition();
    }

    public interface ITransitionService
    {
        void StartTransition(bool forward, object waitParameter);
        void EndTransition();
    }

    public class TransitionService : ITransitionService
    {
        readonly ISupportTransitions _supportTransitions;
        public TransitionService(ISupportTransitions supportTransitions)
        {
            _supportTransitions = supportTransitions;
        }
        public void StartTransition(bool forward, object waitParameter)
        {
            _supportTransitions.StartTransition(forward, waitParameter);
        }
        public void EndTransition()
        {
            _supportTransitions.EndTransition();
        }
    }

    public static class TransitionServiceExtension
    {
        public static IDisposable EnterTransition(this ITransitionService service,
            bool effective = true,
            bool forward = true,
            object waitParameter = null)
        {
            return new TransitionBatch(effective ? service : null, forward, waitParameter);
        }
        class TransitionBatch : IDisposable
        {
            readonly ITransitionService _service;
            public TransitionBatch(ITransitionService service, bool forward, object waitParameter)
            {
                _service = service;
                if (service != null)
                    service.StartTransition(forward, waitParameter);
            }
            public void Dispose()
            {
                if (_service != null)
                    _service.EndTransition();
            }
        }
    }

}
