C# Learning Guide: Advanced C#

This guide will track our progress as we build a single project that demonstrates the core concepts from your Practice/Advanced C# folderhttps://www.google.com/search?q=.

Key Concepts

Delegates

Event Handlers (Events)

try Statements and Exceptions

Enumerator and Iterators

Nullable Value Types

Operator Overloading

Project Tracker: AdvancedFeaturesProject

We will build a simple video encoding notification system, step by stephttps://www.google.com/search?q=.

Step 1: Delegates and Events

Goal: Create a "publisher" (VideoEncoder) that sends a notification (an event) when a video is finished encodinghttps://www.google.com/search?q=. Other "subscriber" classes (EmailService, SMSService) will listen for this event and reacthttps://www.google.com/search?q=.

Concepts Covered:

Delegates: We define VideoEncodedEventHandler as the delegate (the "contract" or "blueprint") for our eventhttps://www.google.com/search?q=.

Event Handlers: We use the event keyword in VideoEncoder to create the notificationhttps://www.google.com/search?q=. The "handler" methods are the OnVideoEncoded methods in the subscriber classeshttps://www.google.com/search?q=.

Files Added:

AdvancedFeaturesProject.csproj

Video.cs

VideoEventArgs.cs

VideoEncoder.cs (The Publisher)

EmailService.cs (A Subscriber)

SMSService.cs (A Subscriber)

Program.cs (Wires everything up)

Step 2: Exception Handling

Goal: (Coming soon)

Concepts Covered: (Coming soon)

Files Modified: (Coming soon)

Step 3: Nullable Value Typesa

Goal: (Coming soon)

Concepts Covered: (Coming soon)

Files Modified: (Coming soon)

Step 4: Operator Overloading

Goal: (Coming soon)

Concepts Covered: (Coming soon)

Files Added/Modified: (Coming soon)

Step 5: Enumerators and Iterators

Goal: (Coming soon)

Concepts Covered: (Coming soon)

Files Added/Modified: (Coming soon)