
using System;
using System.Collections.Generic;

const string Separator = "========================================";
const string ClubName = "Tech Club";
const string ClubDescription = "Technology club for AI and programming";
const string EventTitle = "Workshop AI";
const string CheckInMethod = CheckIn.InPersonMethod;

Console.WriteLine(Separator);
Console.WriteLine("EDUHUB - CONSOLE APP DEMO");
Console.WriteLine(Separator);

// STEP 1: Create club
Console.WriteLine("\nSTEP 1: CREATE CLUB");

Club club = Club.Create(ClubName, ClubDescription);

Console.WriteLine($"Club name: {club.Name}");
Console.WriteLine($"Description: {club.Description}");

// STEP 2: Create 3 members and add them to the club
Console.WriteLine("\n" + Separator);
Console.WriteLine("STEP 2: ADD MEMBERS");

Member member1 = Member.Create(
    "Nguyen Van An", "an@example.com", "SV001");

Member member2 = Member.Create(
    "Tran Thi Binh", "binh@example.com", "SV002");

Member member3 = Member.Create(
    "Le Van Cuong", "cuong@example.com", "SV003");

List<Member> members = new() { member1, member2, member3 };

foreach (Member member in members)
{
    club.AddMember(member);
    Console.WriteLine($"Added member: {member.Name}");
}

Console.WriteLine($"Total members: {club.MemberCount()}");

// STEP 3: Create an event with capacity 50
Console.WriteLine("\n" + Separator);
Console.WriteLine("STEP 3: CREATE EVENT");

Event workshop = Event.Create(
    club.Id,
    EventTitle,
    DateTime.UtcNow.AddDays(7),
    50,
    true);

Console.WriteLine($"Event: {workshop.Title}");
Console.WriteLine($"Capacity: {workshop.Capacity}");
Console.WriteLine($"Online: {workshop.IsOnline}");
Console.WriteLine($"Event date (UTC): {workshop.Date:yyyy-MM-dd HH:mm}");

// STEP 4: Register 2 members and confirm registrations
Console.WriteLine("\n" + Separator);
Console.WriteLine("STEP 4: EVENT REGISTRATIONS");

Registration registration1 = Registration.Create(
    member1.Id, workshop.Id);

Registration registration2 = Registration.Create(
    member2.Id, workshop.Id);

Console.WriteLine(
    $"{member1.Name}: {registration1.Status}");

Console.WriteLine(
    $"{member2.Name}: {registration2.Status}");

registration1.Confirm();
registration2.Confirm();

Console.WriteLine("Confirming registrations...");

Console.WriteLine(
    $"{member1.Name}: {registration1.Status}");

Console.WriteLine(
    $"{member2.Name}: {registration2.Status}");

List<Registration> registrations = new()
{
    registration1,
    registration2
};

// STEP 5: Check in one member
Console.WriteLine("\n" + Separator);
Console.WriteLine("STEP 5: MEMBER CHECK-IN");

CheckIn checkIn = CheckIn.Create(
    registration1.Id,
    CheckInMethod);

Console.WriteLine($"Member: {member1.Name}");
Console.WriteLine(checkIn.Summary());

// STEP 6: Print attendance report
Console.WriteLine("\n" + Separator);
Console.WriteLine("STEP 6: ATTENDANCE REPORT");
Console.WriteLine(Separator);

Console.WriteLine($"Club: {club.Name}");
Console.WriteLine($"Event: {workshop.Title}");
Console.WriteLine($"Event capacity: {workshop.Capacity}");
Console.WriteLine($"Total members in club: {club.MemberCount()}");
Console.WriteLine($"Total registrations: {registrations.Count}");
Console.WriteLine("Total check-ins: 1");

Console.WriteLine("\nRegistration list:");

foreach (Registration registration in registrations)
{
    Member? registeredMember = members.Find(
        member => member.Id == registration.MemberId);

    string memberName = registeredMember?.Name ?? "Unknown member";

    Console.WriteLine(
        $"- {memberName}: {registration.Status}");
}

Console.WriteLine("\nChecked-in member:");
Console.WriteLine($"- {member1.Name}");

Console.WriteLine(Separator);
Console.WriteLine("DEMO COMPLETED SUCCESSFULLY");
Console.WriteLine(Separator);
