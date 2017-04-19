using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.Repo
{
    public enum ActionType
    {
        None,
        Add,
        Update,
        Remove
    }

    public class WorkAction
    {
        public WorkAction
            (ActionType action,
            IEntity entity,
            IEntityWriter writer)
        {
            Action = action;
            Entity = entity;
            Writer = writer;
        }

        public ActionType Action;
        public IEntity Entity;
        public IEntityWriter Writer;
    }
}
