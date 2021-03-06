﻿using OpenProtocolInterpreter.Communication;
using OpenProtocolInterpreter.Job;
using System;

namespace OpenProtocolInterpreter.Sample.Driver.Commands
{
    public class SendJobCommand
    {
        private readonly OpenProtocolDriver driver;

        public SendJobCommand(OpenProtocolDriver driver)
        {
            this.driver = driver;
        }

        public bool Execute(int jobId)
        {
            Console.WriteLine($"Sending job <{jobId}> to controller!");
            var mid = driver.sendAndWaitForResponse(new Mid0038(jobId).Pack(), new TimeSpan(0, 0, 10));

            if (mid.HeaderData.Mid == Mid0004.MID)
            {
                this.onJobRefused(mid as Mid0004);
                return false;
            }

            this.onJobAccepted(mid as Mid0005);
            return true;
        }

        private void onJobAccepted(Mid0005 mid)
        {
            Console.WriteLine("Job Accepted by controller!");
        }

        private void onJobRefused(Mid0004 mid)
        {
            Console.WriteLine($"Job refused by controller under error code <{(int)mid.ErrorCode}> ({mid.ErrorCode.ToString()})!");
        }
    }
}
