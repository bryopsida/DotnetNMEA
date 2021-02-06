# DotnetNMEA
 [![akboyd88](https://circleci.com/gh/akboyd88/DotnetNMEA.svg?style=svg)](https://circleci.com/gh/akboyd88/DotnetNMEA)
[![Documentation Status](https://readthedocs.org/projects/dotnetnmea/badge/?version=latest)](https://dotnetnmea.readthedocs.io/en/latest/namespace_dotnet_n_m_e_a_1_1_n_m_e_a0183.html)
 [![codecov](https://codecov.io/gh/akboyd88/DotnetNMEA/branch/master/graph/badge.svg)](https://codecov.io/gh/akboyd88/DotnetNMEA)
 
## NMEA parsing library 
 
## Supported NMEA 0183 Sentences
| Sentence Type        | Full Support           | Partial Support  |
| ------------- |:-------------:| -----:|
| GGA      | :heavy_check_mark:  |  |
| RMC    | :heavy_check_mark: |   |
| GLL | :heavy_check_mark: |  |
| GSA | :heavy_check_mark: | |
| GSV |  | :heavy_check_mark: |


## Example Usage

```c#

INMEA0183Parser parser = new NMEA0183Parser();

ReadOnlySpan<char> exampleMessage = 
    "$GPRMC,215236.000,A,2006.5938,N,09844.6060,W,0.38,343.75,150919,,,A*70";

switch(mess.Type)
{
    case MessageType.RMC:
    RMCMessage mess = parser.Parse(exampleMessage) as RMCMessage;
    //do something with message
    break;
}
```

## Help Wanted

Device access for testing has been limited so if you have additional NMEA message examples that are not currently supported please submit an issue containing the message string.  Pull requests, suggestions, and requests are always welcome.
