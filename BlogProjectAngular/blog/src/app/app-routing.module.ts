import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddBlogComponent } from './component/add-blog/add-blog.component';
import { DisplayBlogComponent } from './component/display-blog/display-blog.component';
import { EditBlogComponent } from './component/edit-blog/edit-blog.component';

const routes: Routes = [
  {path:'add-blog',component: AddBlogComponent },
  {path:'display-blog',component:DisplayBlogComponent},
  {path:'edit-blog',component:EditBlogComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
