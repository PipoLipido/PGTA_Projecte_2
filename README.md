# **PROJECT P2 MEMORY:** 
ASTERIX HACKATHON 

Biel Amat Planells Albert Castillo Saiz Jan Bayón Juan 

# Read Me 
1. To start the program, double-click on the executable “Decoder.exe”. 
1. A new window appears with 3 buttons: 
- **Download Asterix Sample:** This button opens a tab where you can download the asterix files if they are not already downloaded. 
- **ReadMe**: This button opens a tab where you can access the GitHub repository and read the instructions on how to use the code. 
- **Start Software:** This button opens the decoder window. 
3. Once the decoder window is opened, an empty table and 8 buttons will appear. Each button has a different functionality: 
- **Show Data:** This button allows the user to select an ASTERIX file that you want to decode.  When  pressed,  a  file  selector  will  open.  When  a  user  selects  the corresponding ASTERIX file, it will be loaded into the decoder and when the entire list of messages is decoded into actual parameters, the result will be displayed in the central  table.  This  process  has  a  variable  length  depending  on  the  size  of  the ASTERIX file. The process followed for the decoding of the data is depicted in the flowchart below. 
- **Filters:** This section helps to select in a more accurate way the data that you want to display in the center table. Allows to adjust the search of certain specific messages screening them through type, location or transmitter of the message. 
- *Pure target Filter:* when pressed subtracts all those messages which are not a Mode S communication. Please, note that those Mode S messages aided with PSR or SSR, are also considered as Mose S messages. Hence, the fields in “*TYP*” which do not match with: "Single Mode S All-Call", "Single Mode S Roll-Call", "Mode S All-Call + PSR" and "Mode S Roll-Call + PSR". 
- *Lat/Lon  Filter:*  This  filter  allows  a  selection  of  the  messages  indicating locations which exist inside a delimited geographical area selected by the user. This area has to be specified into a range of latitudes and longitudes. To achieve  it,  all  messages’  latitude  and longitude fields are read and those which have values out of the specified range are afterwards removed with .RemoveAt(). 
- *Delete Aircrafts on ground:* Deletes aircrafts which are not Airborne.Those messages  which  do  not  contain  "No  alert,  no SPI, aircraft on ground" or alternatively "Alert, no SPI, aircraft on ground", are eliminated. 
- *Fixed  Transponder  Filter:*  Deletes  the  messages  transmitted  by  the  fixed transponders. This are the messages with a Mode 3/A equal to 7777. 
- *Reset  Filters:*  When clicked, this button allows the user to recover all the messages existing in the ASTERIX file. 

Notice that all filters can be combined between them. 

- **Map:**  This  button  opens  a  new  window  where  a  map  is  displayed  where  the corresponding planes of the asterix message are represented. This map allows you to track the position of the different planes over time and obtain information about each plane by clicking on the point. The information for each aircraft is: “Aircraft ID”, “Speed” and “Altitude”. 

Additionally the map has different functions: 

- *“Play”  button:*  Starts  the  simulation.  Runs  a  loop  where  it  evaluates  the dataTable and displays the aircraft 
- *“Stop” button:* Stops the simulation. 
- *“Reverse” button:* Runs the simulation time in the opposite direction. 
- *“Reset” button:* Restarts the simulation from the beginning. 
- *“<<” button:* Reduces the speed of the simulation. Reduces the number of seconds per tick of the clock by half in order to do each iteration each time the button is pressed (allowed speeds between x1 to x512). 
- *“>>” button:* Increases the speed of the simulation. Increases the number of seconds per tick of the clock by double for each time the button is pressed (allowed speeds between x1 to x512). 
- **Export to csv:** Exports the displayed table to a csv file. When you click on it, an address  selector  will  open  to  determine the location and name of the file. Once accepted, the “.csv” file will be generated in the corresponding address. 
- **Extras:** As an addition to what explained above one can also check the distance between two aircrafts by pressing them both in the map. Then the stereographic distance between them will be indicated in a label located in the upper left corner. When you select a third plane, the selection will be restarted. 
4. Now, the user should press the *Show data* button and select the file which is to be decodified. Note that this may take a long time. 
4. Finally, the user can adjust the filters as needed to display only the information he is interested in. 
