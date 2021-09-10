import { Component, OnInit } from '@angular/core';
import { BlogService } from 'src/app/blog.service';

@Component({
  selector: 'app-display-blog',
  templateUrl: './display-blog.component.html',
  styleUrls: ['./display-blog.component.css']
})
export class DisplayBlogComponent implements OnInit {

  constructor(public Service: BlogService) { }

  ngOnInit(): void {
    this.Service.getBlog();
  }

  onGetBlog(id:number){
    this.Service.onSetIdForSpecificBlog(id);
  }
}
