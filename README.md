#wxr.net

wxr.net is a simple API for creating Wordpress export files, in Wordpress' WXR format.

## Usage
``` csharp

var site = new Site { Title = "A Test Site" };

var post = new Post
{
		Title = "My First Post",
		Date = DateTime.Now,
		Description = "A post, that was first",
		Content = @"<b>First!</b>"
};

site.SerializeToDisk(@"c:\users\admin\desktop");
```

## Status
wxr.net currently produces valid, importable XML for sites and posts. The API support tags and categories, but they are not importing correctly.

Comments, authors, media etc will be coming soon.

## Installation
For now you will need to build the project yourself. It uses [XMLGuy](https://github.com/benrhughes/xmlguy), but is otherwise has no dependencies.
