import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Blog } from 'src/app/blog';
import { BlogService } from 'src/app/blog.service';

@Component({
  selector: 'app-add-blog',
  templateUrl: './add-blog.component.html',
  styleUrls: ['./add-blog.component.css']
})
export class AddBlogComponent implements OnInit {

  constructor(public service: BlogService) { }

  ngOnInit(): void {
  }

  ResetForm(form: NgForm){
    form.form.reset();
    this.service.blogFormData = new Blog();
  }

  OnSubmit(form: NgForm){
    this.InsertData(form);
  }

  InsertData(form:NgForm){
    this.service.postBlog().subscribe(
      res =>{
        this.ResetForm(form);
        this.service.getBlog();
      },
      err => {console.log(err);}
    )
  }
}
