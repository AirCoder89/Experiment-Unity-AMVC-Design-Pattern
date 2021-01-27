using System;
using System.Collections.Generic;
using AMVC.Core;
using AMVC.Helper;
using AMVC.Views.Loading;
using UnityEngine;
using Application = AMVC.Core.Application;

namespace AMVC.Systems.Loading.CommandDp
{
    public class CommandInvoker : AppSystem
    {
        public event Action OnComplete;
        public float progression;
        
        private Queue<ICommand> _commandsBuffer;
        private ICommand _currentCommand = null;
        private bool _isStart = false;
        private int _nbCommand;
        private LoadingPanel _panel;
        
        public override void Initialize(AppController controller, Application app)
        {
            base.Initialize(controller, app);
            _commandsBuffer = new Queue<ICommand>();
        }

        public void AddCommand(ICommand command)
        {
            _commandsBuffer.Enqueue(command);
        }

        public void StartInvoker()
        {
            StartSystem();
            if(_panel == null)  _panel = GetPanel<LoadingPanel>();
            _panel.UpdateProgress(0f);
            _nbCommand = _commandsBuffer.Count;
            _isStart = _nbCommand > 0;
        }

        public override void Tick()
        {
            if(!IsRun || !_isStart) return;
            if (_commandsBuffer.Count == 0 && _currentCommand.IsDone)
            {
                //all commands complete
                PauseSystem();
                _currentCommand.Dispose();
                _currentCommand = null;
                UpdateProgression();
                OnComplete?.Invoke();
                return;
            }
            if (_currentCommand == null)
            {
                //start first command
                _currentCommand = _commandsBuffer.Dequeue();
                _currentCommand.Execute();
                return;
            }

            if (!_currentCommand.IsDone)
            {
                //_currentCommand in progress
                UpdateProgression();
                return;
            }
            //_currentCommand Complete
            _currentCommand.Dispose();
            _currentCommand = _commandsBuffer.Dequeue();
            _currentCommand.Execute();
        }

        private void UpdateProgression()
        {
            this.progression = (float)(_nbCommand - _commandsBuffer.Count) / _nbCommand;
            _panel.UpdateProgress(this.progression);
        }
    }
}