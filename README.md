# speedtest-logger
A web app to log the results from [speedtest-cli](https://github.com/sivel/speedtest-cli).

![Example Speedtest Graph](https://cdn.laundon.org/speedtest-example.png "Example Speedtest Graph")

The excellent [speedtest.net](http://speedtest.net) is a website to test internet bandwidth.  The GitHub project [speedtest-cli](https://github.com/sivel/speedtest-cli) by [Matt Martz](https://github.com/sivel/) is a python-based commandline interface that replicates the flash-based speedtest website.  One of the options in speedtest-cli is the option **--share** which posts the test results to the speedtest.net webserver in order to generate an image that can be shared.

Minor changes to *speedtest_cli.py* can allow these results to be posted to a different location.  This project allows the capture of those speedtest results, and display them in an easy to read manner so that problems with bandwidth at different times of day can be identified. Cron or Task Scheduler can be used to schedule the script to run at regular intervals.

The project is written in ASP.Net MVC, and uses [Dapper](https://github.com/StackExchange/dapper-dot-net) as a Micro ORM.  The default code assumes MS SQL as a back-end, but a single line change can use any of the database engines supported by Dapper, including MySQL.

##Current Version
The current version is an improvement to the initial release, and loads the data using ajax.  There are now controls to choose a time range, and th option to exclude ping data from that chart.

##VNext
Version 3.0 will will tidy up the Google Chart options, and expand date ranges with date pickers.

##Changes to speedtest_cli.py

Grab [speedtest-cli](https://github.com/sivel/speedtest-cli) and then [speedtest_cli.py] (https://github.com/sivel/speedtest-cli/blob/master/speedtest_cli.py).

The section to edit is at the very end, around line 750:
```python
# Build the request to send results back to speedtest.net
        # We use a list instead of a dict because the API expects parameters
        # in a certain order
        apiData = [
            'download=%s' % dlspeedk,
            'ping=%s' % ping,
            'upload=%s' % ulspeedk,
            'promo=',
            'startmode=%s' % 'pingselect',
            'recommendedserverid=%s' % best['id'],
            'accuracy=%s' % 1,
            'serverid=%s' % best['id'],
            'hash=%s' % md5(('%s-%s-%s-%s' %
                             (ping, ulspeedk, dlspeedk, 'myPasswordHere'))
                            .encode()).hexdigest()]

        headers = {'Referer': 'http://c.speedtest.net/flash/speedtest.swf'}
        request = build_request('http://server/speedtest-logger/log',
                                data='&'.join(apiData).encode(),
                                headers=headers)
```
The key changes are

(ping, ulspeedk, dlspeedk, '~~297aae72~~ **myPasswordHere**'))

and

request = build_request('~~://www.speedtest.net/api/api.php~~ **http://server/speedtest-logger/log**', 

##Structure
The project is in two parts: [speedtest-logger](https://github.com/jamielaundon/speedtest-logger/tree/master/src/speedtest-logger) which is the MVC web page and API, and [speedtest-common](https://github.com/jamielaundon/speedtest-logger/tree/master/src/speedtest-common) which is the database logic.

* / - Main web page. Loads data using ajax (see below).
* /log - URL where the speedtest-cli data is posted to
* /json - Google Chart datatable json
  * /json/days/x - get data for x days
  * /json/hours/x - get data for x hours
  * /json/range/x/y - get data between range of two dates x and y
  * /json/all - get all data
* /table - html table partial view
  * /table/days/x - get data for x days
  * /table/hours/x - get data for x hours
  * /table/range/x/y - get data between range of two dates x and y
  * /table/all - get all data 

##Example
[https://jamie.laundon.org/speedtest-logger/](https://jamie.laundon.org/speedtest-logger/)


