PROBLEM:
As a company that runs HTTP services, questions of scale often come up. When you want to determine how a service will scale
before turning it loose in the wild, it's often prudent to run a load test to simulate your expected traffic. A good load
generator should be able to provide ample RPS (requests per second) to help drive out potential performance problems before
any of your new users see them - the higher the better.

We would like you to construct a simple HTTP load generator client using modern async practices. It should accept an input file
specifying details like hostname, path, and requests per second, and then continuously generate the requested load until the program
has been shut down. It should also handle/report on any obviously erroneous behavior from the server.

This task should be timeboxed at somewhere around 2-3 hours; we are not expecting a world-class application, but merely
would like to get to know you better as a developer through your code. Internet sources are valid for this program, but please use
'good work rules': if you wouldn't do it for a work project, please don't do it here. Please feel free to use any programming
language that you deem appropriate.

DETAILS:
   * Server URL: https://bevan1p0d8.execute-api.us-east-1.amazonaws.com/Live
   * Permissions (in Header): 'X-Api-Key: 5FQREQBeHX9jTwi1ts3vkaPkdAdUyNfNaITfZ75m'
   * Example Request Payload (in JSON): { "name": "YOUR_NAME", "date": "1/1/2022 12:00:00 AM", "requests_sent": 123 }
      * "date" is now in UTC.
      * "requests_sent" is the number of requests sent so far this session.
   * Expected Response Payload (in JSON): { "successful": true }

REQUIREMENTS:
   * Program must accept file-based input for: serverURL, targetRPS, authKey. Additional parameters may be added as desired for
     your clarity and ease of use.
   * Program must send up valid request body payload.
   * Program must sanely handle typical HTTP server responses.
   * Program must periodically output to the console the current RPS and target RPS.
   * Generated load must not exceed target RPS for a session.
   * Program must generate load for as long as desired by the user.
   * After the run has completed, program must output a summary of run including relevant request/response metrics.
   * Your API key is limited to 100,000 requests. Please contact us if you need that limit raised for any reason.

SUBMISSION:
   * We will review your code during one of your interview sessions and talk through design decisions and tradeoffs.
   * For the interview session, please be prepared to share your screen as you discuss your code.

IMPROVEMENTS:
   * Include a button to discontinue the load generator so Ctrl+C isn't depended on.
   * Output current and target RPS.
   * Keep track of which requests passed and failed, including time they passed, total count, argument data, etc.
   * Have each request each it's own thread rather than a for-loop.
   * Create a controller class to generate a variety of input to the request.
   * I haven't worked with C# before so study more of it to provide faster implementation.