using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockHandAngle
{
    class Clock
    {
        /*
         * Clock Class -
         * Provides functionality for determining the angle between clock hands
         * */

        // Private data members
        private double minute;
        private double hour;
        private const double MINUTE_ANGLE = 6;
        private const double HOUR_ANGLE = 30;
        private const double HOUR_PER_MIN_ANGLE = 0.5;

        // Properties
        public double Minute
        {
            get { return minute; }
            set {
                // Validate the value
                while (value >= 60)
                {
                    value -= 60;
                }
                minute = value;
            }
        }

        public double Hour
        {
            get { return hour; }
            set {
                // Validate the value
                while (value >= 12)
                {
                    value -= 12;
                }
                hour = value;
            }
        }

        // Constructors
        public Clock()
        {
            // Default constructor
            // Sets the time to the current time
            hour = DateTime.Now.Hour;
            minute = DateTime.Now.Minute;
        }

        public Clock(double hr, double min)
        {
            // Sets time to the given input
            hour = hr;
            minute = min;
        }

        // Methods
        public double Calculate()
        {
            /*
             * Calculate -
             * Determines the angle between the hour and minute hands
             * */

            // Variables
            double finalAngle;
            double minuteAngle;
            double hourAngle;

            // Calculate the angle the minute hand is at from 0
            minuteAngle = minute * MINUTE_ANGLE;

            // Calculate the angle the hour hand is at from 0
            hourAngle = hour * HOUR_ANGLE;

            // Compensate for the movement of the hour hand based on the minute
            hourAngle += minute * HOUR_PER_MIN_ANGLE;

            // Find the finalAngle based on which angle is larger
            if (hourAngle >= minuteAngle)
            {
                finalAngle = hourAngle - minuteAngle;
            }
            else
            {
                finalAngle = minuteAngle - hourAngle;
            }

            // If the finalAngle is > 180, calculate the small angle.
            if (finalAngle > 180)
            {
                finalAngle -= 180;
            }

            // All done! Return it!
            return finalAngle;
        }
    }
}
