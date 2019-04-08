﻿using System;
using System.Collections.Generic;

namespace CalendarExample.X
{
    /// <summary>
    /// Common Class for working days functionality
    /// </summary>
    public class CalendarHelper
    {
        /// <summary>
        /// Get Next Calendar date time based on parameter
        /// </summary>
        /// <param name="dateTime">date time</param>
        /// <param name="unit">Unit to elapse in date time</param>
        /// <param name="unitType">Unit type (day/hour)</param>
        /// <returns></returns>
        public static DateTime GetNextCalendarDate(DateTime dateTime, int unit, string unitType)
        {
            switch (unitType)
            {
                case "hour":
                    return dateTime.AddHours(unit);
                case "day":
                    return dateTime.AddDays(unit);
                default:
                    break;
            }
            return dateTime;
        }

        /// <summary>
        /// Find Next Working Date time based on parameter
        /// </summary>
        /// <param name="dateTime">date time</param>
        /// <param name="calendarDates">Dictionary of day working time</param>
        /// <param name="holidays">List of holiday dates</param>
        /// <param name="unit">Unit to elapse in date time</param>
        /// <param name="unitType">Unit type (day/hour)</param>
        /// <returns></returns>
        public static DateTime FindWorkingDate(DateTime dateTime, Dictionary<DayOfWeek, DateTime[,]> calendarDates, List<DateTime> holidays, int unit, string unitType)
        {
            DateTime startWorkingDateTime = dateTime;
            DateTime workingStartTime;
            DateTime workingEndTime;
            DateTime endWorkingDateTime = dateTime;
            TimeSpan duration = new TimeSpan();
            TimeSpan workingTime = new TimeSpan();
            TimeSpan timeElapsed = new TimeSpan();
            bool nonWorkingDay = false;
            bool dayFound = false;
            TimeSpan leftWorkingTime = new TimeSpan();
            bool nonWorkingTime = false;
            int workingDays = 0;

            switch (unitType)
            {
                case "day":
                    duration = new TimeSpan(unit, 0, 0, 0);
                    break;
                case "hour":
                    duration = new TimeSpan(unit, 0, 0);
                    break;
                default:
                    break;
            }
            // Get start working date and time
            while (IsHoliday(startWorkingDateTime, holidays) || !IsWorkingDate(startWorkingDateTime, calendarDates))
            {
                nonWorkingDay = true;
                startWorkingDateTime = startWorkingDateTime.AddDays(1);
            }

            DateTime[,] workTime = calendarDates[startWorkingDateTime.DayOfWeek];
            if (startWorkingDateTime != dateTime)
            {
                startWorkingDateTime = new DateTime(startWorkingDateTime.Year, startWorkingDateTime.Month, startWorkingDateTime.Day, workTime[0, 0].Hour, workTime[0, 0].Minute, workTime[0, 0].Second);
            }
            workingStartTime = new DateTime(startWorkingDateTime.Year, startWorkingDateTime.Month, startWorkingDateTime.Day, workTime[0, 0].Hour, workTime[0, 0].Minute, workTime[0, 0].Second);
            workingEndTime = new DateTime(startWorkingDateTime.Year, startWorkingDateTime.Month, startWorkingDateTime.Day, workTime[0, 1].Hour, workTime[0, 1].Minute, workTime[0, 1].Second);
            if (startWorkingDateTime < workingStartTime)
                nonWorkingTime = true;
            if (workingStartTime < startWorkingDateTime && startWorkingDateTime < workingEndTime || nonWorkingDay)
                leftWorkingTime = workingEndTime.Subtract(startWorkingDateTime);
            if (startWorkingDateTime < workingEndTime)
                workingTime = workingEndTime.Subtract(workingStartTime);

            if (unitType == "hour" && duration > leftWorkingTime && leftWorkingTime.Ticks > 0)
            {
                workingDays++;
                duration = duration - leftWorkingTime;
                startWorkingDateTime = startWorkingDateTime.AddDays(1);
                // Get start working date and time
                while (IsHoliday(startWorkingDateTime, holidays) || !IsWorkingDate(startWorkingDateTime, calendarDates))
                {
                    startWorkingDateTime = startWorkingDateTime.AddDays(1);
                }
                workTime = calendarDates[startWorkingDateTime.DayOfWeek];
                workingStartTime = new DateTime(startWorkingDateTime.Year, startWorkingDateTime.Month, startWorkingDateTime.Day, workTime[0, 0].Hour, workTime[0, 0].Minute, workTime[0, 0].Second);
                workingEndTime = new DateTime(startWorkingDateTime.Year, startWorkingDateTime.Month, startWorkingDateTime.Day, workTime[0, 1].Hour, workTime[0, 1].Minute, workTime[0, 1].Second);
                workingTime = workingEndTime.Subtract(workingStartTime);
            }
            else if (unitType == "day")
            {
                if (nonWorkingDay || nonWorkingTime)
                    unit--;
                else
                {
                    if (workingStartTime < startWorkingDateTime && startWorkingDateTime < workingEndTime && !nonWorkingDay)
                        timeElapsed = startWorkingDateTime.Subtract(workingStartTime);
                }
            }

            switch (unitType)
            {
                case "hour":
                    while (!dayFound)
                    {
                        if (duration > workingTime)
                        {
                            duration = duration - workingTime;
                            workingDays++;
                            //Set to next date                        
                            workingEndTime = workingEndTime.AddDays(1);
                            while (IsHoliday(workingEndTime, holidays) || !IsWorkingDate(workingEndTime, calendarDates))
                            {
                                workingEndTime = workingEndTime.AddDays(1);
                            }
                            workTime = calendarDates[workingEndTime.DayOfWeek];
                            workingStartTime = new DateTime(workingEndTime.Year, workingEndTime.Month, workingEndTime.Day, workTime[0, 0].Hour, workTime[0, 0].Minute, workTime[0, 0].Second);
                            workingEndTime = new DateTime(workingEndTime.Year, workingEndTime.Month, workingEndTime.Day, workTime[0, 1].Hour, workTime[0, 1].Minute, workTime[0, 1].Second);
                            workingTime = workingEndTime.Subtract(workingStartTime);
                        }
                        else
                        {
                            if (workingDays > 0 || nonWorkingTime)
                                endWorkingDateTime = workingStartTime.Add(duration);
                            else
                                endWorkingDateTime = startWorkingDateTime.Add(duration);
                            dayFound = true;
                        }
                    }
                    break;
                case "day":
                    int counter = unit;
                    int nonWorkingDays = 0;
                    while (counter > 0)
                    {
                        //Set to next date                        
                        workingEndTime = workingEndTime.AddDays(1);
                        if (IsHoliday(workingEndTime, holidays) || !IsWorkingDate(workingEndTime, calendarDates))
                            nonWorkingDays++;
                        else
                            counter = counter - 1;
                    }

                    workTime = calendarDates[workingEndTime.DayOfWeek];
                    workingStartTime = new DateTime(workingEndTime.Year, workingEndTime.Month, workingEndTime.Day, workTime[0, 0].Hour, workTime[0, 0].Minute, workTime[0, 0].Second);
                    workingEndTime = new DateTime(workingEndTime.Year, workingEndTime.Month, workingEndTime.Day, workTime[0, 1].Hour, workTime[0, 1].Minute, workTime[0, 1].Second);

                    if (nonWorkingDay || timeElapsed.Ticks == 0)
                        endWorkingDateTime = workingEndTime;
                    else
                    {
                        workingTime = workingEndTime.Subtract(workingStartTime);
                        while (!dayFound)
                        {
                            if (timeElapsed > workingTime)
                            {
                                timeElapsed = timeElapsed - workingTime;
                                //Set to next date                        
                                workingEndTime = workingEndTime.AddDays(1);
                                while (IsHoliday(workingEndTime, holidays) || !IsWorkingDate(workingEndTime, calendarDates))
                                {
                                    workingEndTime = workingEndTime.AddDays(1);
                                }
                                workTime = calendarDates[workingEndTime.DayOfWeek];
                                workingStartTime = new DateTime(workingEndTime.Year, workingEndTime.Month, workingEndTime.Day, workTime[0, 0].Hour, workTime[0, 0].Minute, workTime[0, 0].Second);
                                workingEndTime = new DateTime(workingEndTime.Year, workingEndTime.Month, workingEndTime.Day, workTime[0, 1].Hour, workTime[0, 1].Minute, workTime[0, 1].Second);
                                workingTime = workingEndTime.Subtract(workingStartTime);
                            }
                            else
                            {
                                endWorkingDateTime = workingStartTime.Add(timeElapsed);
                                dayFound = true;
                            }
                        }
                    }
                    break;
                default:
                    break;
            }
            return endWorkingDateTime;
        }

        /// <summary>
        /// Check whether the date is holiday
        /// </summary>
        /// <param name="dateTime">date time</param>
        /// <param name="holidays">List of holiday dates</param>
        /// <returns></returns>
        /// <history>
        /// Revision    Date        Author          Description
        /// 6.0.8.0     25/01/2011  AJPunchithaya   Removed validation based on .Contains() logic
        /// </history>
        public static bool IsHoliday(DateTime dateTime, List<DateTime> holidays)
        {
            bool isHoliday = false;
            DateTime checkDate = new DateTime(dateTime.Year, dateTime.Month, dateTime.Day);
            foreach (DateTime holiday in holidays)
            {
                DateTime holidayDate = new DateTime(holiday.Year, holiday.Month, holiday.Day);
                if (DateTime.Equals(checkDate, holidayDate))
                {
                    isHoliday = true;
                    break;
                }
            }
            return isHoliday;
        }

        /// <summary>
        /// Check whether the day is a working day
        /// </summary>
        /// <param name="dateTime">date time</param>
        /// <param name="calendarDate">Dictionary of working date time</param>
        /// <returns></returns>
        public static bool IsWorkingDate(DateTime dateTime, Dictionary<DayOfWeek, DateTime[,]> calendarDate)
        {
            if (calendarDate.ContainsKey(dateTime.DayOfWeek))
                return true;
            else
                return false;
        }

        /// <summary>
        /// Get working time in hour between from and to date
        /// </summary>
        /// <param name="fromDate">from date</param>
        /// <param name="toDate">to date</param>
        /// <param name="calendarDates">Dictionary of day working time</param>
        /// <param name="holidays">List of holiday dates</param>
        /// <returns></returns>
        public static decimal GetWorkingTimeInHour(DateTime fromDate, DateTime toDate, Dictionary<DayOfWeek, DateTime[,]> calendarDates, List<DateTime> holidays)
        {
            DateTime startWorkingDateTime = fromDate;
            DateTime workingStartTime;
            DateTime workingEndTime;
            TimeSpan duration = new TimeSpan();
            TimeSpan workingTime = new TimeSpan();
            bool nonWorkingDay = false;
            decimal hours = 0;

            if (fromDate >= toDate)
                return 0;
            else
            {
                // Get start working date and time
                while (IsHoliday(startWorkingDateTime, holidays) || !IsWorkingDate(startWorkingDateTime, calendarDates))
                {
                    startWorkingDateTime = startWorkingDateTime.AddDays(1);
                    nonWorkingDay = true;
                }

                DateTime[,] workTime = calendarDates[startWorkingDateTime.DayOfWeek];
                workingStartTime = new DateTime(startWorkingDateTime.Year, startWorkingDateTime.Month, startWorkingDateTime.Day, workTime[0, 0].Hour, workTime[0, 0].Minute, workTime[0, 0].Second);
                workingEndTime = new DateTime(startWorkingDateTime.Year, startWorkingDateTime.Month, startWorkingDateTime.Day, workTime[0, 1].Hour, workTime[0, 1].Minute, workTime[0, 1].Second);
                workingTime = workingEndTime.Subtract(workingStartTime);
                if (toDate < workingEndTime)
                {
                    if (nonWorkingDay)
                        if (toDate > workingStartTime)
                            duration = toDate.Subtract(workingStartTime);
                        else
                            // No actual working time spend
                            duration = new TimeSpan(0);
                    else if (startWorkingDateTime < workingStartTime)
                    {
                        if (toDate > workingStartTime)
                            duration = toDate.Subtract(workingStartTime);
                        else
                            // No actual working time spend
                            duration = new TimeSpan(0);
                    }
                    else if (workingStartTime < startWorkingDateTime && startWorkingDateTime < workingEndTime)
                        duration = toDate.Subtract(startWorkingDateTime);
                }
                else
                {
                    if (nonWorkingDay)
                        duration = workingEndTime.Subtract(workingStartTime);
                    else if (startWorkingDateTime < workingStartTime)
                        duration = workingEndTime.Subtract(workingStartTime);
                    else if (workingStartTime < startWorkingDateTime && startWorkingDateTime < workingEndTime)
                        duration = workingEndTime.Subtract(startWorkingDateTime);
                }

                while (workingEndTime < toDate)
                {
                    workingEndTime = workingEndTime.AddDays(1);
                    // Get next working date and time
                    while (IsHoliday(workingEndTime, holidays) || !IsWorkingDate(workingEndTime, calendarDates))
                    {
                        workingEndTime = workingEndTime.AddDays(1);
                    }
                    workTime = calendarDates[workingEndTime.DayOfWeek];
                    workingStartTime = new DateTime(workingEndTime.Year, workingEndTime.Month, workingEndTime.Day, workTime[0, 0].Hour, workTime[0, 0].Minute, workTime[0, 0].Second);
                    workingEndTime = new DateTime(workingEndTime.Year, workingEndTime.Month, workingEndTime.Day, workTime[0, 1].Hour, workTime[0, 1].Minute, workTime[0, 1].Second);
                    if (toDate < workingStartTime)
                        break;
                    else if (workingEndTime > toDate)
                    {
                        duration = duration + toDate.Subtract(workingStartTime);
                    }
                    else
                        duration = duration + workingEndTime.Subtract(workingStartTime);
                }


                hours = System.Math.Round(duration.Days * 24 + duration.Hours + (decimal)duration.Minutes / 60 + (decimal)duration.Seconds / 3600, 2);

                return hours;
            }
        }

        /// <summary>
        /// Get time difference in hour from start time to end time
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static decimal GetCalendarTimeInHour(DateTime fromDate, DateTime toDate)
        {
            if (fromDate >= toDate)
                return 0;
            else
            {
                TimeSpan duration = toDate.Subtract(fromDate);
                decimal hours = System.Math.Round(duration.Days * 24 + duration.Hours + (decimal)duration.Minutes / 60 + (decimal)duration.Seconds / 3600, 2);
                return hours;
            }
        }


        /// <summary>
        /// Find next working date for a calendar
        /// </summary>
        /// <returns></returns>
        public static DateTime FindNextWorkingDay(DateTime dateTime, Dictionary<DayOfWeek, DateTime[,]> calendarDates, List<DateTime> holidays)
        {
            DateTime nexttWorkingDay;
            dateTime = dateTime.AddDays(1);
            // Get previous working date
            while (IsHoliday(dateTime, holidays) || !IsWorkingDate(dateTime, calendarDates))
            {
                dateTime = dateTime.AddDays(1);
            }
            nexttWorkingDay = dateTime;
            return nexttWorkingDay;
        }

        /// <summary>
        /// Find previous working date for a calendar
        /// </summary>
        /// <returns></returns>
        public static DateTime FindPreviousWorkingDay(DateTime dateTime, Dictionary<DayOfWeek, DateTime[,]> calendarDates, List<DateTime> holidays)
        {
            DateTime previousWorkingDay;
            dateTime = dateTime.AddDays(-1);
            // Get previous working date
            while (IsHoliday(dateTime, holidays) || !IsWorkingDate(dateTime, calendarDates))
            {
                dateTime = dateTime.AddDays(-1);
            }
            previousWorkingDay = dateTime;
            return previousWorkingDay;
        }


        /// <summary>
        /// Check if it is last working date for a calendar from today
        /// </summary>
        /// <returns></returns>
        public static bool IsLastWorkingDate(DateTime dateTime, Dictionary<DayOfWeek, DateTime[,]> calendarDates, List<DateTime> holidays)
        {
            DateTime previousWorkingDay;
            dateTime = dateTime.AddDays(-1);
            // Get previous working date
            while (IsHoliday(dateTime, holidays) || !IsWorkingDate(dateTime, calendarDates))
            {
                dateTime = dateTime.AddDays(-1);
            }
            previousWorkingDay = dateTime;
            if (previousWorkingDay < DateTime.Today)
                return true;
            else
                return false;
        }
    }
}
