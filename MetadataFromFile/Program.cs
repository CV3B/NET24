/*
    Vi vill skapa en console applikation som tar ett (sökväg) filnamn som input. 
    Programmet ska sedan, genom att läsa in binärdata, 
    avgöra om filen man angett är en .bmp fil eller en .png fil, 
    samt ange höjd och bredd på bilden i pixlar. 
    Om filen man angett varken är en .bmp eller .png så skriver vi det.
    
    Exempel output:
    "File not found."
    "This is not a valid .bmp or .png file!"
    "This is a .png image. Resolution: 800x600 pixels."
*/


string inputPNG = @"C:\Users\calle\Pictures\pngBild.png";
string inputBMP = @"C:\Users\calle\Pictures\bmpBild.bmp";


byte[] byteInputPNG = File.ReadAllBytes(inputPNG);
byte[] byteInputBMP = File.ReadAllBytes(inputBMP);

foreach (byte b in byteInputPNG) Console.WriteLine(b);