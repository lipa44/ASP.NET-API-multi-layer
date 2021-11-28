using System;
using System.Collections.Generic;
using System.Linq;
using Reports.Employees.Abstractions;
using Reports.Entities;
using Reports.Tools;

namespace Reports.Employees
{
    public class TeamLead : Employee
    {
        private readonly List<WorkTeam> _teams = new ();

        public TeamLead(string name, string surname, Guid passportId)
            : base(name, surname, passportId)
        { }

        public void AddWorkTeam(WorkTeam workTeam)
        {
            ArgumentNullException.ThrowIfNull(workTeam);

            if (IsWorkTeamExist(workTeam))
                throw new ReportsException($"{workTeam} team already exists in {this}'s teams");

            _teams.Add(workTeam);
        }

        public void RemoveWorkTeam(WorkTeam workTeam)
        {
            ArgumentNullException.ThrowIfNull(workTeam);

            if (!_teams.Remove(workTeam))
                throw new ReportsException($"{workTeam} team doesn't exists in {this}'s teams");
        }

        private bool IsWorkTeamExist(WorkTeam workTeam) => _teams.Any(t => t.Id == workTeam.Id);
    }
}