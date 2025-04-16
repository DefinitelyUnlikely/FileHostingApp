# General thoughts

## A short version of the demands of the "customer" (My instructor at school). 
** MVP **
An API that allows one to create new folders (which in turn can contain folders.)
Note on Deletion of folders: Do customer want it to be recursive or only allow the deletion of empty folders? 
Upload files to specific folder
delete files
download files

Files should be saved to a postgresSQL database. Through EnityFramework. 

** end of MVP **

Implement security and users with IdentityCore to meet customers wishlist.

# Thoughts on backend

## Database
First thing I need to decide is the structure of the database. 

So, back to structure: 

**A table for files:**
a primary key, probably a GUID/UUID.
a foreign key, pointing to which folder is the parent of the file. I think this is the easiest way to create a perceived structure. 
No parent id will make me assume the file is at the top level, should be shown directly.
A column that indicates the files extension
a column containing the file itself, or well, the bytes that makes up the file. 
possibly the complete 'path' of the file, if it turns out just using parent folder id is too cumbersome/resource demanding. 


**A table for folders:**
An id, GUID.
an id of the parent folder, if it has one. No parent id will make me assume the path is the top level directory.

## API / Endpoints

What endpoints do I need? 

folder - Create. 
folder/id - Delete a folder, read contents of a folder. update the content of a folder. 
file - Create a file. Get all files? 
file/id - Get a file, delete a file, update a file. 
search?queryparams=something&queryparam2=something2 - a search endpoint, that should look through all your files and return those with matching regex

# Thoughts on frontend

I'll go with a backend first approach, meaning once I am done with the backend, I'll do the frontend (and then iterate as needed). 
So, I'll not decide on anything directly, but React or Angular seems like the current candidates for a frontend.

But how do I want the design to look and feel? My first instinct is to either mimic what we already know from windows/linux. 
Either with 1 folder per row, then 1 item per row, or more like how once desktop usaully look. Perhaps even let the user pick between
different icon sizes.

But if I don't let em pick, I think I want largeish icons. I want the ability to drag and drop these icons to make moving files 
intuitive. Look into making ctrl x work? i.e. things users are already used to. All of this is of course icing on the cake. 

what's the frontend MVP? just the paths shown in a list?