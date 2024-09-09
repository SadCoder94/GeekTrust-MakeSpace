using System;

namespace MakeSpace.FunctionalClasses
{
    public abstract class Command
    {
        public abstract string Execute(Scheduler scheduler);
    }

    public class VacancyCommand : Command
    {
        private DateTime startDate;
        private DateTime endDate;
        private bool isValid;

        public VacancyCommand(DateTime startDate, DateTime endDate, bool isValid)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.isValid = isValid;
        }

        public override string Execute(Scheduler scheduler)
        {
            if (!isValid || endDate < startDate)
            {
                return "INCORRECT_INPUT";
            }

            var vacancies = scheduler.ViewVacancy(startDate, endDate);
            return vacancies;
        }
    }

    public class BookCommand : Command
    {
        private DateTime startDate;
        private DateTime endDate;
        private int capacity;
        private bool isValid;

        public BookCommand(DateTime startDate, DateTime endDate, int capacity, bool isValid)
        {
            this.startDate = startDate;
            this.endDate = endDate;
            this.capacity = capacity;
            this.isValid = isValid;
        }

        public override string Execute(Scheduler scheduler)
        {
            if (!isValid || endDate < startDate)
            {
                return "INCORRECT_INPUT";
            }

            var booking = scheduler.BookRoom(startDate, endDate, capacity);
            return booking;
        }
    }
}
