#wxr.net

wxr.net is a simple API for creating files to be imported into Wordpress, using the WXR format.

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

site.Posts.Add(post);

site.SerializeToDisk(@"c:\users\admin\desktop");
```

## Status
wxr.net currently produces valid, importable XML for sites, posts, tags and categories.

Comments, authors, media etc will be coming soon.

## Installation
For now you will need to build the project yourself. It uses [XMLGuy](https://github.com/benrhughes/xmlguy), but is otherwise has no dependencies.
