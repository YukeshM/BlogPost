import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { BlogService } from 'src/app/blog.service';

@Component({
  selector: 'app-edit-blog',
  templateUrl: './edit-blog.component.html',
  styleUrls: ['./edit-blog.component.css']
})
export class EditBlogComponent implements OnInit {

  constructor(public Service: BlogService, private router: Router) { }

  ngOnInit(): void {
    this.Service.getBlog();
    console.log(this.Service.id);
    this.Service.list.forEach(blog =>{
      if(blog.id == this.Service.id)
      {
        this.Service.blogFormData.BlogId = blog.id;
        this.Service.blogFormData.BlogTitle = blog.blogTitle;
        this.Service.blogFormData.Content = blog.content;
      }
    });
  }

  onSubmit(form: NgForm){
    this.insertData(form);
  }

  insertData(form: NgForm){
    this.Service.putBlog().subscribe(
      res =>{
        this.Service.getBlog();
      },
      err =>{
        console.log(err);
      }
    )
    //TODO:
    this.router.navigateByUrl('')
  }
}
