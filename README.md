# Waze2Geo
 Convert Waze JSON to GeoJSON
 
 ## Helpful Links
 [Test GeoJSON for validity and see it on a map](http://geojsonlint.com/)  
 [GeoJSON Feature Type Examples](https://en.wikipedia.org/wiki/GeoJSON)  
 [GeoJSON example file and some other info](https://gist.github.com/sgillies/1233327)
 
 ## How to use
 Waze2Geo uses [.NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2) to fetch JSON data from Waze (at https://na-georss.waze.com), convert that JSON to GeoJSON, and save it to a json file on the computer it runs on.  
 
In a terminal/PowerShell window, cd to the project directory, run `dotnet build` and then run `dotnet Waze2Geo.dll` and simply paste in the polygon coordinates for the area you would like Waze GeoJSON data for. Note: I am going off memory for these steps so they may not work...  

Example of a "polygon area": `-82.039000,30.848000;-81.663000,30.792000;-81.336000,30.815000;-81.341000,30.275000;-81.198000,29.690000;-81.453000,29.707000;-81.709000,29.762000;-81.824000,30.062000;-82.165000,30.100000;-82.086000,30.371000;-82.039000,30.848000`
  
Waze2Geo will continue running so that you can paste in polygon array after polygon array. GeoJSON files are written to the relative root path of the DLL file (e.g. Waze2Geo/bin/Debug/netcoreapp2.2/**waze_10-11-2019_05_11.json**. Note that files will be overwritten if you go fast enough such that the new file was created in the same minute the last file was created. Timestamp on the file is in UTC.
 
## FAQs
**How long does it take to generate a GeoJSON file for a polygon?**
It's very fast, less than a second usually. I haven't tested it with a polygon the size of Florida, but it should still be very fast. The slowest part will probably always be the time it takes to get the JSON from Waze's servers.  

**Why is the GeoJSON file saved to the relative root of the program?**
I don't know which operating system(s) this is going to run on, and saving outside the relative root of the program often leads to permissions issues depending on the operating system, meaning the file can't be written.  
  
**Can the GeoJSON file be saved somewhere else?**
Yes! With enough effort it can be saved literally anywhere. Your desktop. *My* desktop. A NAS drive somewhere. AWS Glacier. Etc.
