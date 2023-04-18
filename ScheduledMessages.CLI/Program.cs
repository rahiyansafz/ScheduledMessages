
using Microsoft.Extensions.Configuration;

using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

IConfigurationRoot configuration = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

string twilioAccountSid = configuration["TwilioAccountSid"] ?? "";
string twilioAuthToken = configuration["TwilioAuthToken"] ?? "";
string twilioMessagingServiceSid = configuration["TwilioMessagingServiceSid"] ?? "";

TwilioClient.Init(twilioAccountSid, twilioAuthToken);

var toNumber = new PhoneNumber("<to number>");
var firstMessageOptions = new CreateMessageOptions(toNumber)
{
    Body = "Hi, tomorrow is a special day. So be ready for a big surprise.",
    MessagingServiceSid = twilioMessagingServiceSid,
    SendAt = DateTime.UtcNow.AddMinutes(16),
    ScheduleType = MessageResource.ScheduleTypeEnum.Fixed
};

var firstMessage = MessageResource.Create(firstMessageOptions);

Console.WriteLine($"First Message SID: {firstMessage.Sid}");
Console.WriteLine($"First Message Status: {firstMessage.Status}");

// Send second message
var secondMessageOptions = new CreateMessageOptions(toNumber)
{
    Body = "Today is a special day, so at 6:00 p.m. wait at the corner of Y and X streets.",
    MessagingServiceSid = twilioMessagingServiceSid,
    SendAt = DateTime.UtcNow.AddMinutes(17),
    ScheduleType = MessageResource.ScheduleTypeEnum.Fixed
};

var secondMessage = MessageResource.Create(secondMessageOptions);

Console.WriteLine($"Second Message SID: {secondMessage.Sid}");
Console.WriteLine($"Second Message Status: {secondMessage.Status}");

// Send the third message
var thirdMessageOptions = new CreateMessageOptions(toNumber)
{
    Body = "It's 11:59 pm and has been a wonderful day and I hope you have enjoyed this wonderful dinner with me.",
    MessagingServiceSid = twilioMessagingServiceSid,
    SendAt = DateTime.UtcNow.AddMinutes(18),
    ScheduleType = MessageResource.ScheduleTypeEnum.Fixed
};

var thirdMessage = MessageResource.Create(thirdMessageOptions);

Console.WriteLine($"Third Message SID: {thirdMessage.Sid}");
Console.WriteLine($"Third Message Status: {thirdMessage.Status}");