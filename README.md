WIP tool to allow me to use Unity's far nicer 3D editor to create A-frame scene html

How to use:
Open the Scene HTMLBuilder and select the html builder object. Tick the box "Generate HTML" to generate it in the console using Debug.Log. Copy everything from <html> to </html> inclusive into an IDE that supports a-frame and live preview and see the scene copied.
Note you will have to place any images in the same folder as the html file for now, named identically to file in unity, and update the img extension in html builder if not using png. 

delete all objects except the HTML Builder one and add prefabs from the prefab folder to add spheres, cubes, images to the scene and scale, rotate, position as normal. Or create a new scene and add the Html Builder prefab to it. 
Check Generate HTML to get the html and don't forget to scroll down. 

Limitations: so far have only made boxes/cubes, spheres, sky, scene, image objects. Obviously there are lots more a-frame elements and properties.  I might add text and other elements later. It's a very basic string creator so the more types of object and properties supported will make it very messy- This is just a proof of concept.


