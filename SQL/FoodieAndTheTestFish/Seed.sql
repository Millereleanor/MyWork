USE [FoodieAndTheTestFish]
GO
INSERT [dbo].[IdentityUser] ([UserId], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [CreateBy], [CreateDate], [ModifyBy], [ModifyDate]) VALUES (N'87e8fca7-c2fa-40d6-b9de-b226056455ac', N'hisuida@me.com', 0, N'APtZMtSev5OwwVfhdNNbdY5sCXxkX0/gS+sXxzfmW8+6TLpzzUzok+kp6j3rrmB3uw==', N'7387b2ca-32f6-4b70-90dd-60a3ab7ad4cc', NULL, 0, 0, CAST(N'1753-01-01 00:00:00.000' AS DateTime), 1, 0, N'hisuida@me.com', N'00000000-0000-0000-0000-000000000000', CAST(N'2016-04-24 00:42:00' AS SmallDateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2016-04-24 00:42:00' AS SmallDateTime))
GO
INSERT [dbo].[IdentityUser] ([UserId], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [CreateBy], [CreateDate], [ModifyBy], [ModifyDate]) VALUES (N'd4cdc38c-5e60-4238-9c36-bbe39ec4e018', N'chuck@you.up', 0, N'AL6YNhSyHum+kCreOoDNDXe5Ba6icTkUQ4bZdsX+t8JlLNz6+6Zz9JvwFzKzGQxpdA==', N'd24cb409-a2ea-45bb-8651-5df3a92da910', NULL, 0, 0, CAST(N'1753-01-01 00:00:00.000' AS DateTime), 1, 0, N'chuck@you.up', N'00000000-0000-0000-0000-000000000000', CAST(N'2016-04-25 13:07:00' AS SmallDateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2016-04-25 13:07:00' AS SmallDateTime))
GO
SET IDENTITY_INSERT [dbo].[Statuses] ON 

GO
INSERT [dbo].[Statuses] ([StatusId], [Type]) VALUES (1, N'Pending')
GO
INSERT [dbo].[Statuses] ([StatusId], [Type]) VALUES (2, N'Active')
GO
INSERT [dbo].[Statuses] ([StatusId], [Type]) VALUES (3, N'Inactive')
GO
INSERT [dbo].[Statuses] ([StatusId], [Type]) VALUES (4, N'Denied')
GO
INSERT [dbo].[Statuses] ([StatusId], [Type]) VALUES (5, N'Featured')
GO
SET IDENTITY_INSERT [dbo].[Statuses] OFF
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

GO
INSERT [dbo].[Categories] ([CategoryId], [Category]) VALUES (1, N'Recipes')
GO
INSERT [dbo].[Categories] ([CategoryId], [Category]) VALUES (2, N'Reviews')
GO
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[SubCategories] ON 

GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [CategoryId], [SubCategory]) VALUES (1, 1, N'Breakfast')
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [CategoryId], [SubCategory]) VALUES (3, 1, N'Lunch')
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [CategoryId], [SubCategory]) VALUES (4, 1, N'Dinner')
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [CategoryId], [SubCategory]) VALUES (5, 1, N'Dessert')
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [CategoryId], [SubCategory]) VALUES (6, 1, N'Drinks')
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [CategoryId], [SubCategory]) VALUES (7, 2, N'NorthAmerica')
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [CategoryId], [SubCategory]) VALUES (8, 2, N'SouthAmerica')
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [CategoryId], [SubCategory]) VALUES (9, 2, N'Asia')
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [CategoryId], [SubCategory]) VALUES (10, 2, N'Europe')
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [CategoryId], [SubCategory]) VALUES (11, 2, N'Australia')
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [CategoryId], [SubCategory]) VALUES (12, 2, N'Africa')
GO
INSERT [dbo].[SubCategories] ([SubCategoryId], [CategoryId], [SubCategory]) VALUES (13, 2, N'Antarctica')
GO
SET IDENTITY_INSERT [dbo].[SubCategories] OFF
GO
SET IDENTITY_INSERT [dbo].[BlogPosts] ON 

GO
INSERT [dbo].[BlogPosts] ([BlogId], [UserId], [SubCategoryId], [StatusId], [MainPictureUrl], [Title], [PostContent], [Summary], [CreatedOn], [PublishDate], [ExpirationDate], [ApprovedOn]) VALUES (1, N'87e8fca7-c2fa-40d6-b9de-b226056455ac', 7, 1, N'https://grubamericana.files.wordpress.com/2012/08/hamburger_love-normal.jpg', N'Best Burger Ever!', N'<p>Best Hamburger Evar!&nbsp;</p>
<p><img src="https://grubamericana.files.wordpress.com/2012/08/hamburger_love-normal.jpg" alt="" width="650" height="551" /></p>
<p>Bacon ipsum dolor amet consectetur ex ullamco tail. Turducken duis shankle, pork belly fugiat culpa cow dolore pork loin tri-tip quis short ribs doner. Aliquip ribeye capicola, in short ribs irure rump cupidatat. Bacon jerky tongue pork chop incididunt reprehenderit. Proident exercitation beef frankfurter.</p>
<p>Chicken voluptate pancetta, in reprehenderit dolore dolore aute tenderloin occaecat deserunt. Boudin drumstick capicola, elit ex voluptate culpa. Sint tongue salami, occaecat filet mignon irure ground round labore ball tip. Duis cupidatat pig aute biltong chicken. Swine est consectetur venison, pig salami mollit porchetta adipisicing officia pariatur kevin ex. Esse deserunt bacon ut labore sed, magna adipisicing picanha pork loin. Ball tip tri-tip ut chicken nisi.</p>
<p>&nbsp;</p>
<p><img src="http://www.gannett-cdn.com/-mm-/de0a34e464f1c8b5b0737ec2a91519fc37e97b79/c=1-0-767-1022&amp;r=537&amp;c=0-0-534-712/local/-/media/2016/01/07/Livonia/B9320422051Z.1_20160107223802_000_GFAD3CS9I.1-0.jpg" alt="" width="400" height="533" /></p>
<p>Fugiat nulla sint ut alcatra, beef ribs adipisicing. Venison dolor incididunt irure. Capicola laborum venison, officia boudin sint sunt est kielbasa fatback cillum pastrami. Ea et andouille, landjaeger reprehenderit t-bone esse. Exercitation cow magna, turkey adipisicing id mollit proident. Alcatra ea dolore pancetta aliquip.</p>
<p>Rump short ribs jowl dolor ad laborum alcatra biltong beef ribs nulla pastrami. Swine short ribs venison cupim ad. Anim deserunt cupidatat tempor. Rump cupidatat pork belly sirloin voluptate ut doner venison shank dolore beef ribs picanha andouille. Jowl anim deserunt magna velit meatloaf. Tail aliqua in pork capicola picanha.</p>
<p>Drumstick chuck fatback eu bacon, chicken aliquip ad irure venison turducken laborum tempor. Porchetta nulla ipsum veniam, pork chop cupim drumstick quis jerky in aliqua cupidatat ball tip andouille nostrud. Chicken in aute short ribs beef ribs. Bacon brisket mollit, tempor pig qui commodo drumstick dolore laboris pork chop chuck landjaeger doner. Biltong kevin prosciutto, sirloin chuck laboris tempor mollit dolore pork belly nulla quis velit ut sausage. Nisi non qui rump venison reprehenderit est.</p>', N'Best Hamburger in the world!', CAST(N'2016-04-23' AS Date), NULL, NULL, NULL)
GO
INSERT [dbo].[BlogPosts] ([BlogId], [UserId], [SubCategoryId], [StatusId], [MainPictureUrl], [Title], [PostContent], [Summary], [CreatedOn], [PublishDate], [ExpirationDate], [ApprovedOn]) VALUES (2, N'd4cdc38c-5e60-4238-9c36-bbe39ec4e018', 1, 1, N'http://cfile7.uf.tistory.com/image/2136B73451773EAC2D88B6', N'Korea BBQ Buffet', N'<p>South Korea: Seoul: BBQ Buffet!</p>
<p><img src="http://mblogthumb4.phinf.naver.net/20120806_283/barbies01_13442212527361jGeA_JPEG/IMG_7583_copy.JPG?type=w2" alt="" width="550" height="366" /></p>
<p>Bacon ipsum dolor amet consectetur ex ullamco tail. Turducken duis shankle, pork belly fugiat culpa cow dolore pork loin tri-tip quis short ribs doner. Aliquip ribeye capicola, in short ribs irure rump cupidatat. Bacon jerky tongue pork chop incididunt reprehenderit. Proident exercitation beef frankfurter.</p>
<p>Chicken voluptate pancetta, in reprehenderit dolore dolore aute tenderloin occaecat deserunt. Boudin drumstick capicola, elit ex voluptate culpa. Sint tongue salami, occaecat filet mignon irure ground round labore ball tip. Duis cupidatat pig aute biltong chicken. Swine est consectetur venison, pig salami mollit porchetta adipisicing officia pariatur kevin ex. Esse deserunt bacon ut labore sed, magna adipisicing picanha pork loin. Ball tip tri-tip ut chicken nisi.</p>
<p><img src="http://cfile9.uf.tistory.com/image/27373C355271B9103693D5" alt="" width="500" height="333" /></p>
<p>Fugiat nulla sint ut alcatra, beef ribs adipisicing. Venison dolor incididunt irure. Capicola laborum venison, officia boudin sint sunt est kielbasa fatback cillum pastrami. Ea et andouille, landjaeger reprehenderit t-bone esse. Exercitation cow magna, turkey adipisicing id mollit proident. Alcatra ea dolore pancetta aliquip.</p>
<p>Rump short ribs jowl dolor ad laborum alcatra biltong beef ribs nulla pastrami. Swine short ribs venison cupim ad. Anim deserunt cupidatat tempor. Rump cupidatat pork belly sirloin voluptate ut doner venison shank dolore beef ribs picanha andouille. Jowl anim deserunt magna velit meatloaf. Tail aliqua in pork capicola picanha.</p>
<p>Drumstick chuck fatback eu bacon, chicken aliquip ad irure venison turducken laborum tempor. Porchetta nulla ipsum veniam, pork chop cupim drumstick quis jerky in aliqua cupidatat ball tip andouille nostrud. Chicken in aute short ribs beef ribs. Bacon brisket mollit, tempor pig qui commodo drumstick dolore laboris pork chop chuck landjaeger doner. Biltong kevin prosciutto, sirloin chuck laboris tempor mollit dolore pork belly nulla quis velit ut sausage. Nisi non qui rump venison reprehenderit est.</p>', N'Unlimited Meat! BBQ Buffet in Seoul', CAST(N'2016-04-24' AS Date), NULL, NULL, NULL)
GO
INSERT [dbo].[BlogPosts] ([BlogId], [UserId], [SubCategoryId], [StatusId], [MainPictureUrl], [Title], [PostContent], [Summary], [CreatedOn], [PublishDate], [ExpirationDate], [ApprovedOn]) VALUES (4, N'87e8fca7-c2fa-40d6-b9de-b226056455ac', 5, 2, N'http://www.driscolls.com/content/images/recipe-images/recipe_detail_b94987bd0119a8f390b4899555208b6c.jpg', N'Strawberry Shortcake', N'<p>Strawberry Shortcake!&nbsp;</p>
<p><img src="http://www.easyproteinshakes.com/wp-content/uploads/2013/06/strawberryshortcake100.jpg" alt="" width="500" height="332" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Oat cake chocolate bar sweet chupa chups lollipop sweet roll oat cake sweet marshmallow. Gingerbread cookie toffee gingerbread liquorice. Jelly beans pie bonbon chocolate bar halvah. Pie danish sugar plum sesame snaps biscuit icing gummi bears gingerbread. Biscuit cake gingerbread. Biscuit icing cotton candy cheesecake.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Liquorice candy biscuit chocolate. Icing gummi bears sweet sesame snaps tootsie roll bonbon sweet roll. Pie chupa chups brownie tootsie roll sesame snaps brownie tiramisu. Jelly muffin lemon drops. Croissant pudding danish gingerbread toffee marzipan sesame snaps. Cake wafer sweet roll halvah danish lemon drops carrot cake.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding"><img src="https://i.ytimg.com/vi/UoMiCDp_dTc/maxresdefault.jpg" alt="" width="500" height="281" /></span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Macaroon apple pie tiramisu marzipan muffin caramels sweet roll pie chupa chups. Jelly beans marzipan apple pie cake donut topping marshmallow topping brownie. Topping dessert drag&eacute;e chocolate bar. Powder croissant lollipop pastry macaroon. Toffee bonbon jelly beans cheesecake sugar plum. Donut cotton candy icing ice cream donut.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Gummies dessert bonbon liquorice cookie pudding sugar plum. Sugar plum toffee danish jelly chocolate liquorice croissant marzipan. Carrot cake wafer cotton candy wafer donut souffl&eacute; souffl&eacute; icing. Cake jelly-o icing lemon drops. Chocolate jelly beans sugar plum. Brownie oat cake biscuit candy canes jelly. Liquorice tiramisu tootsie roll carrot cake sweet roll jelly beans fruitcake.</span></p>', N'All Stawberry Lovers Rejoice!', CAST(N'2016-04-24' AS Date), NULL, NULL, CAST(N'2016-04-25' AS Date))
GO
INSERT [dbo].[BlogPosts] ([BlogId], [UserId], [SubCategoryId], [StatusId], [MainPictureUrl], [Title], [PostContent], [Summary], [CreatedOn], [PublishDate], [ExpirationDate], [ApprovedOn]) VALUES (6, N'd4cdc38c-5e60-4238-9c36-bbe39ec4e018', 4, 5, N'http://www.newyorker.com/wp-content/uploads/2015/03/Sushi-Cat-1200.jpg', N'Sushi Making for Dummies', N'<p>Sushi Making for Dummies</p>
<p><img src="http://www-tc.pbs.org/food/files/2012/09/Sushi-5-1.jpg" alt="" width="600" height="450" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Oat cake chocolate bar sweet chupa chups lollipop sweet roll oat cake sweet marshmallow. Gingerbread cookie toffee gingerbread liquorice. Jelly beans pie bonbon chocolate bar halvah. Pie danish sugar plum sesame snaps biscuit icing gummi bears gingerbread. Biscuit cake gingerbread. Biscuit icing cotton candy cheesecake.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Liquorice candy biscuit chocolate. Icing gummi bears sweet sesame snaps tootsie roll bonbon sweet roll. Pie chupa chups brownie tootsie roll sesame snaps brownie tiramisu. Jelly muffin lemon drops. Croissant pudding danish gingerbread toffee marzipan sesame snaps. Cake wafer sweet roll halvah danish lemon drops carrot cake.</span></p>
<p class="paragraph ng-attr-widget"><img src="http://www.asianabistroct.com/resources/1p1l0596rbxwz3rnlvzvnvk8292r.jpg" alt="" width="664" height="378" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Macaroon apple pie tiramisu marzipan muffin caramels sweet roll pie chupa chups. Jelly beans marzipan apple pie cake donut topping marshmallow topping brownie. Topping dessert drag&eacute;e chocolate bar. Powder croissant lollipop pastry macaroon. Toffee bonbon jelly beans cheesecake sugar plum. Donut cotton candy icing ice cream donut.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Gummies dessert bonbon liquorice cookie pudding sugar plum. Sugar plum toffee danish jelly chocolate liquorice croissant marzipan. Carrot cake wafer cotton candy wafer donut souffl&eacute; souffl&eacute; icing. Cake jelly-o icing lemon drops. Chocolate jelly beans sugar plum. Brownie oat cake biscuit candy canes jelly. Liquorice tiramisu tootsie roll carrot cake sweet roll jelly beans fruitcake.</span></p>', N'Make Sushi Using this One Weird Method. All Sushi Chefs Hate Us!', CAST(N'2016-04-24' AS Date), NULL, NULL, CAST(N'2016-04-26' AS Date))
GO
INSERT [dbo].[BlogPosts] ([BlogId], [UserId], [SubCategoryId], [StatusId], [MainPictureUrl], [Title], [PostContent], [Summary], [CreatedOn], [PublishDate], [ExpirationDate], [ApprovedOn]) VALUES (7, N'87e8fca7-c2fa-40d6-b9de-b226056455ac', 12, 5, N'http://desigrub.com/wp-content/uploads/2010/03/ethiopian_platter.jpg', N'Ethiopian Food: The New Hip Dish', N'<p><img src="https://s-media-cache-ak0.pinimg.com/736x/12/c7/a0/12c7a0293db7f4bf89bc23127f4417a8.jpg" alt="" width="400" height="467" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Oat cake chocolate bar sweet chupa chups lollipop sweet roll oat cake sweet marshmallow. Gingerbread cookie toffee gingerbread liquorice. Jelly beans pie bonbon chocolate bar halvah. Pie danish sugar plum sesame snaps biscuit icing gummi bears gingerbread. Biscuit cake gingerbread. Biscuit icing cotton candy cheesecake.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Liquorice candy biscuit chocolate. Icing gummi bears sweet sesame snaps tootsie roll bonbon sweet roll. Pie chupa chups brownie tootsie roll sesame snaps brownie tiramisu. Jelly muffin lemon drops. Croissant pudding danish gingerbread toffee marzipan sesame snaps. Cake wafer sweet roll halvah danish lemon drops carrot cake.</span></p>
<p class="paragraph ng-attr-widget"><img src="http://www.howtocookgreatethiopian.com/new/wp-content/uploads/ethiopian-food-vegan-spinach-potato-gomen-addis-ababa-injera1.jpg" alt="" width="450" height="299" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Macaroon apple pie tiramisu marzipan muffin caramels sweet roll pie chupa chups. Jelly beans marzipan apple pie cake donut topping marshmallow topping brownie. Topping dessert drag&eacute;e chocolate bar. Powder croissant lollipop pastry macaroon. Toffee bonbon jelly beans cheesecake sugar plum. Donut cotton candy icing ice cream donut.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Gummies dessert bonbon liquorice cookie pudding sugar plum. Sugar plum toffee danish jelly chocolate liquorice croissant marzipan. Carrot cake wafer cotton candy wafer donut souffl&eacute; souffl&eacute; icing. Cake jelly-o icing lemon drops. Chocolate jelly beans sugar plum. Brownie oat cake biscuit candy canes jelly. Liquorice tiramisu tootsie roll carrot cake sweet roll jelly beans fruitcake.</span></p>', N'Ethiopian dishes are the new craze in town', CAST(N'2016-04-24' AS Date), NULL, NULL, CAST(N'2016-04-24' AS Date))
GO
INSERT [dbo].[BlogPosts] ([BlogId], [UserId], [SubCategoryId], [StatusId], [MainPictureUrl], [Title], [PostContent], [Summary], [CreatedOn], [PublishDate], [ExpirationDate], [ApprovedOn]) VALUES (8, N'd4cdc38c-5e60-4238-9c36-bbe39ec4e018', 13, 5, N'http://cfile221.uf.daum.net/image/145A36534DD3C741089AA3', N'Korea''s Many Noodles..In Antarctica??', N'<p><img src="http://img.lifestyler.co.kr/uploads/program/cheditor/2011/08/SNRIFA9ATUG16PSBLDSC.jpg" alt="" width="600" height="403" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Oat cake chocolate bar sweet chupa chups lollipop sweet roll oat cake sweet marshmallow. Gingerbread cookie toffee gingerbread liquorice. Jelly beans pie bonbon chocolate bar halvah. Pie danish sugar plum sesame snaps biscuit icing gummi bears gingerbread. Biscuit cake gingerbread. Biscuit icing cotton candy cheesecake.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Liquorice candy biscuit chocolate. Icing gummi bears sweet sesame snaps tootsie roll bonbon sweet roll. Pie chupa chups brownie tootsie roll sesame snaps brownie tiramisu. Jelly muffin lemon drops. Croissant pudding danish gingerbread toffee marzipan sesame snaps. Cake wafer sweet roll halvah danish lemon drops carrot cake.</span></p>
<p class="paragraph ng-attr-widget"><img src="https://t1.daumcdn.net/thumb/R1280x0/?fname=http://t1.daumcdn.net/brunch/service/user/zYX/image/QvEyv6KVqSCALrK7pYjyRO4zCJI.jpg" alt="" width="600" height="360" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Macaroon apple pie tiramisu marzipan muffin caramels sweet roll pie chupa chups. Jelly beans marzipan apple pie cake donut topping marshmallow topping brownie. Topping dessert drag&eacute;e chocolate bar. Powder croissant lollipop pastry macaroon. Toffee bonbon jelly beans cheesecake sugar plum. Donut cotton candy icing ice cream donut.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding"><img src="http://cfile8.uf.tistory.com/image/22532F3E50F5DE06293FB1" alt="" width="600" height="400" /></span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Gummies dessert bonbon liquorice cookie pudding sugar plum. Sugar plum toffee danish jelly chocolate liquorice croissant marzipan. Carrot cake wafer cotton candy wafer donut souffl&eacute; souffl&eacute; icing. Cake jelly-o icing lemon drops. Chocolate jelly beans sugar plum. Brownie oat cake biscuit candy canes jelly. Liquorice tiramisu tootsie roll carrot cake sweet roll jelly beans fruitcake.</span></p>', N'Koreans sure love Noodles!', CAST(N'2016-04-24' AS Date), NULL, NULL, CAST(N'2016-04-25' AS Date))
GO
INSERT [dbo].[BlogPosts] ([BlogId], [UserId], [SubCategoryId], [StatusId], [MainPictureUrl], [Title], [PostContent], [Summary], [CreatedOn], [PublishDate], [ExpirationDate], [ApprovedOn]) VALUES (10, N'87e8fca7-c2fa-40d6-b9de-b226056455ac', 1, 2, N'http://images-cdn.9gag.com/photo/anK1wAL_700b_v2.jpg', N'Omelette Du Fromage', N'<p><img src="https://i.ytimg.com/vi/Y72nEd3ZpBs/maxresdefault.jpg" alt="" width="600" height="300" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Oat cake chocolate bar sweet chupa chups lollipop sweet roll oat cake sweet marshmallow. Gingerbread cookie toffee gingerbread liquorice. Jelly beans pie bonbon chocolate bar halvah. Pie danish sugar plum sesame snaps biscuit icing gummi bears gingerbread. Biscuit cake gingerbread. Biscuit icing cotton candy cheesecake.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Liquorice candy biscuit chocolate. Icing gummi bears sweet sesame snaps tootsie roll bonbon sweet roll. Pie chupa chups brownie tootsie roll sesame snaps brownie tiramisu. Jelly muffin lemon drops. Croissant pudding danish gingerbread toffee marzipan sesame snaps. Cake wafer sweet roll halvah danish lemon drops carrot cake.</span></p>
<p class="paragraph ng-attr-widget"><img src="http://www.fromagesbergeron.com/upload/2013/07/presentation-omelette-fromage-bergeron-classique-tastevino-1024x679.jpg" alt="" width="600" height="398" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Macaroon apple pie tiramisu marzipan muffin caramels sweet roll pie chupa chups. Jelly beans marzipan apple pie cake donut topping marshmallow topping brownie. Topping dessert drag&eacute;e chocolate bar. Powder croissant lollipop pastry macaroon. Toffee bonbon jelly beans cheesecake sugar plum. Donut cotton candy icing ice cream donut.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Gummies dessert bonbon liquorice cookie pudding sugar plum. Sugar plum toffee danish jelly chocolate liquorice croissant marzipan. Carrot cake wafer cotton candy wafer donut souffl&eacute; souffl&eacute; icing. Cake jelly-o icing lemon drops. Chocolate jelly beans sugar plum. Brownie oat cake biscuit candy canes jelly. Liquorice tiramisu tootsie roll carrot cake sweet roll jelly beans fruitcake.</span></p>', N'Omlette Du Fromage!!', CAST(N'2016-04-05' AS Date), NULL, NULL, CAST(N'2016-04-10' AS Date))
GO
INSERT [dbo].[BlogPosts] ([BlogId], [UserId], [SubCategoryId], [StatusId], [MainPictureUrl], [Title], [PostContent], [Summary], [CreatedOn], [PublishDate], [ExpirationDate], [ApprovedOn]) VALUES (12, N'd4cdc38c-5e60-4238-9c36-bbe39ec4e018', 3, 3, N'http://www.hawaiimagazine.com/images/content/Hawaii_udon_saimin_broth_recipe_noodles_mail_order/Saimin.JPG.jpeg', N'Saimin, Brah-!', N'<p><img src="https://chroniccravings.files.wordpress.com/2013/10/wp_20130824_003-800x450.jpg" alt="" width="600" height="338" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Oat cake chocolate bar sweet chupa chups lollipop sweet roll oat cake sweet marshmallow. Gingerbread cookie toffee gingerbread liquorice. Jelly beans pie bonbon chocolate bar halvah. Pie danish sugar plum sesame snaps biscuit icing gummi bears gingerbread. Biscuit cake gingerbread. Biscuit icing cotton candy cheesecake.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Liquorice candy biscuit chocolate. Icing gummi bears sweet sesame snaps tootsie roll bonbon sweet roll. Pie chupa chups brownie tootsie roll sesame snaps brownie tiramisu. Jelly muffin lemon drops. Croissant pudding danish gingerbread toffee marzipan sesame snaps. Cake wafer sweet roll halvah danish lemon drops carrot cake.</span></p>
<p class="paragraph ng-attr-widget"><img src="http://www.tastyislandhawaii.com/images/sun_saimin2.jpg" alt="" width="600" height="575" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Macaroon apple pie tiramisu marzipan muffin caramels sweet roll pie chupa chups. Jelly beans marzipan apple pie cake donut topping marshmallow topping brownie. Topping dessert drag&eacute;e chocolate bar. Powder croissant lollipop pastry macaroon. Toffee bonbon jelly beans cheesecake sugar plum. Donut cotton candy icing ice cream donut.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Gummies dessert bonbon liquorice cookie pudding sugar plum. Sugar plum toffee danish jelly chocolate liquorice croissant marzipan. Carrot cake wafer cotton candy wafer donut souffl&eacute; souffl&eacute; icing. Cake jelly-o icing lemon drops. Chocolate jelly beans sugar plum. Brownie oat cake biscuit candy canes jelly. Liquorice tiramisu tootsie roll carrot cake sweet roll jelly beans fruitcake.</span></p>', N'Aloha from Hawaii! And Saimin! ', CAST(N'2016-04-01' AS Date), NULL, NULL, CAST(N'2016-04-05' AS Date))
GO
INSERT [dbo].[BlogPosts] ([BlogId], [UserId], [SubCategoryId], [StatusId], [MainPictureUrl], [Title], [PostContent], [Summary], [CreatedOn], [PublishDate], [ExpirationDate], [ApprovedOn]) VALUES (14, N'87e8fca7-c2fa-40d6-b9de-b226056455ac', 8, 2, N'http://2.bp.blogspot.com/-Nc1XQPuvR8c/TtfEMHy1qwI/AAAAAAAACuc/jsCPUBT6ynk/s1600/moqueca-de-peixe.jpg', N'Gumbo? No! Moqueca! ', N'<p><img src="https://img.peixeurbano.com.br/?img=https://s3.amazonaws.com/pu-mgr/default/a0RG000000i171LMAQ/55e43e37e4b00d323e74a327.jpg&amp;w=620&amp;h=400" alt="" width="600" height="387" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Oat cake chocolate bar sweet chupa chups lollipop sweet roll oat cake sweet marshmallow. Gingerbread cookie toffee gingerbread liquorice. Jelly beans pie bonbon chocolate bar halvah. Pie danish sugar plum sesame snaps biscuit icing gummi bears gingerbread. Biscuit cake gingerbread. Biscuit icing cotton candy cheesecake.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Liquorice candy biscuit chocolate. Icing gummi bears sweet sesame snaps tootsie roll bonbon sweet roll. Pie chupa chups brownie tootsie roll sesame snaps brownie tiramisu. Jelly muffin lemon drops. Croissant pudding danish gingerbread toffee marzipan sesame snaps. Cake wafer sweet roll halvah danish lemon drops carrot cake.</span></p>
<p class="paragraph ng-attr-widget"><img src="https://legrandvin.files.wordpress.com/2012/11/makro_speciale_moqueca_com_vinhos1.jpeg" alt="" width="600" height="364" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Macaroon apple pie tiramisu marzipan muffin caramels sweet roll pie chupa chups. Jelly beans marzipan apple pie cake donut topping marshmallow topping brownie. Topping dessert drag&eacute;e chocolate bar. Powder croissant lollipop pastry macaroon. Toffee bonbon jelly beans cheesecake sugar plum. Donut cotton candy icing ice cream donut.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Gummies dessert bonbon liquorice cookie pudding sugar plum. Sugar plum toffee danish jelly chocolate liquorice croissant marzipan. Carrot cake wafer cotton candy wafer donut souffl&eacute; souffl&eacute; icing. Cake jelly-o icing lemon drops. Chocolate jelly beans sugar plum. Brownie oat cake biscuit candy canes jelly. Liquorice tiramisu tootsie roll carrot cake sweet roll jelly beans fruitcake.</span></p>', N'Brazil''s popular traditional dish, Fish Moqueca-.', CAST(N'2016-03-16' AS Date), NULL, NULL, CAST(N'2016-04-11' AS Date))
GO
INSERT [dbo].[BlogPosts] ([BlogId], [UserId], [SubCategoryId], [StatusId], [MainPictureUrl], [Title], [PostContent], [Summary], [CreatedOn], [PublishDate], [ExpirationDate], [ApprovedOn]) VALUES (16, N'd4cdc38c-5e60-4238-9c36-bbe39ec4e018', 11, 1, N'http://www.taste.com.au/images/recipes/sfi/2003/09/aussie-meat-pies-7273_l.jpeg', N'Have some Meat Pie, Mate!', N'<p><img src="http://www.foodlve.com/dailymotion/saved_images/img53c1260936bfb6.51659073.jpg" alt="" width="600" height="338" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Oat cake chocolate bar sweet chupa chups lollipop sweet roll oat cake sweet marshmallow. Gingerbread cookie toffee gingerbread liquorice. Jelly beans pie bonbon chocolate bar halvah. Pie danish sugar plum sesame snaps biscuit icing gummi bears gingerbread. Biscuit cake gingerbread. Biscuit icing cotton candy cheesecake.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Liquorice candy biscuit chocolate. Icing gummi bears sweet sesame snaps tootsie roll bonbon sweet roll. Pie chupa chups brownie tootsie roll sesame snaps brownie tiramisu. Jelly muffin lemon drops. Croissant pudding danish gingerbread toffee marzipan sesame snaps. Cake wafer sweet roll halvah danish lemon drops carrot cake.</span></p>
<p class="paragraph ng-attr-widget"><img src="http://images.goodfood.com.au/2013/01/21/3969146/GF_729_oz_pies-620x0.jpg" alt="" width="600" height="338" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Macaroon apple pie tiramisu marzipan muffin caramels sweet roll pie chupa chups. Jelly beans marzipan apple pie cake donut topping marshmallow topping brownie. Topping dessert drag&eacute;e chocolate bar. Powder croissant lollipop pastry macaroon. Toffee bonbon jelly beans cheesecake sugar plum. Donut cotton candy icing ice cream donut.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Gummies dessert bonbon liquorice cookie pudding sugar plum. Sugar plum toffee danish jelly chocolate liquorice croissant marzipan. Carrot cake wafer cotton candy wafer donut souffl&eacute; souffl&eacute; icing. Cake jelly-o icing lemon drops. Chocolate jelly beans sugar plum. Brownie oat cake biscuit candy canes jelly. Liquorice tiramisu tootsie roll carrot cake sweet roll jelly beans fruitcake.</span></p>', N'After running away from gigantic spiders and angry Emus, why not have a meat pie?', CAST(N'2016-04-24' AS Date), NULL, NULL, CAST(N'2016-04-26' AS Date))
GO
INSERT [dbo].[BlogPosts] ([BlogId], [UserId], [SubCategoryId], [StatusId], [MainPictureUrl], [Title], [PostContent], [Summary], [CreatedOn], [PublishDate], [ExpirationDate], [ApprovedOn]) VALUES (18, N'87e8fca7-c2fa-40d6-b9de-b226056455ac', 10, 1, N'http://bestguidedtoursinrome.com/wp-content/uploads/2014/11/italian-pizza-cooking-classes.jpg', N'Best Pizza from Rome! ', N'<p><img src="http://foodloversodyssey.com/wp-content/uploads/2010/08/6a010536a07d60970b01348656eb46970c-800wi.jpg" alt="" width="600" height="376" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Oat cake chocolate bar sweet chupa chups lollipop sweet roll oat cake sweet marshmallow. Gingerbread cookie toffee gingerbread liquorice. Jelly beans pie bonbon chocolate bar halvah. Pie danish sugar plum sesame snaps biscuit icing gummi bears gingerbread. Biscuit cake gingerbread. Biscuit icing cotton candy cheesecake.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Liquorice candy biscuit chocolate. Icing gummi bears sweet sesame snaps tootsie roll bonbon sweet roll. Pie chupa chups brownie tootsie roll sesame snaps brownie tiramisu. Jelly muffin lemon drops. Croissant pudding danish gingerbread toffee marzipan sesame snaps. Cake wafer sweet roll halvah danish lemon drops carrot cake.</span></p>
<p class="paragraph ng-attr-widget"><img src="http://www.noodlesandcurry.com/wp-content/uploads/2014/05/DSCF3675.jpg" alt="" width="600" height="400" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Macaroon apple pie tiramisu marzipan muffin caramels sweet roll pie chupa chups. Jelly beans marzipan apple pie cake donut topping marshmallow topping brownie. Topping dessert drag&eacute;e chocolate bar. Powder croissant lollipop pastry macaroon. Toffee bonbon jelly beans cheesecake sugar plum. Donut cotton candy icing ice cream donut.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Gummies dessert bonbon liquorice cookie pudding sugar plum. Sugar plum toffee danish jelly chocolate liquorice croissant marzipan. Carrot cake wafer cotton candy wafer donut souffl&eacute; souffl&eacute; icing. Cake jelly-o icing lemon drops. Chocolate jelly beans sugar plum. Brownie oat cake biscuit candy canes jelly. Liquorice tiramisu tootsie roll carrot cake sweet roll jelly beans fruitcake.</span></p>', N'Let''s get Pizza from Rome. Seems logical enough. ', CAST(N'2016-04-23' AS Date), NULL, NULL, CAST(N'2016-04-24' AS Date))
GO
INSERT [dbo].[BlogPosts] ([BlogId], [UserId], [SubCategoryId], [StatusId], [MainPictureUrl], [Title], [PostContent], [Summary], [CreatedOn], [PublishDate], [ExpirationDate], [ApprovedOn]) VALUES (19, N'd4cdc38c-5e60-4238-9c36-bbe39ec4e018', 6, 1, N'http://www.bottlemart.com.au/Assets/9663/1/Strawberry-Daiquiri-Desktop.jpg', N'How to make the best Strawberry Daiquiri', N'<p><img src="http://unsophisticook.com/wp-content/uploads/2012/05/Easy-Strawberry-Daiquiri-Recipe.jpg" alt="" width="529" height="353" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Oat cake chocolate bar sweet chupa chups lollipop sweet roll oat cake sweet marshmallow. Gingerbread cookie toffee gingerbread liquorice. Jelly beans pie bonbon chocolate bar halvah. Pie danish sugar plum sesame snaps biscuit icing gummi bears gingerbread. Biscuit cake gingerbread. Biscuit icing cotton candy cheesecake.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Liquorice candy biscuit chocolate. Icing gummi bears sweet sesame snaps tootsie roll bonbon sweet roll. Pie chupa chups brownie tootsie roll sesame snaps brownie tiramisu. Jelly muffin lemon drops. Croissant pudding danish gingerbread toffee marzipan sesame snaps. Cake wafer sweet roll halvah danish lemon drops carrot cake.</span></p>
<p class="paragraph ng-attr-widget"><img src="http://www.westsideliquor.com/wp-content/uploads/2013/05/Strawberry-Daiquiri.jpg" alt="" width="600" height="402" /></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Macaroon apple pie tiramisu marzipan muffin caramels sweet roll pie chupa chups. Jelly beans marzipan apple pie cake donut topping marshmallow topping brownie. Topping dessert drag&eacute;e chocolate bar. Powder croissant lollipop pastry macaroon. Toffee bonbon jelly beans cheesecake sugar plum. Donut cotton candy icing ice cream donut.</span></p>
<p class="paragraph ng-attr-widget"><span class="ng-directive ng-binding">Gummies dessert bonbon liquorice cookie pudding sugar plum. Sugar plum toffee danish jelly chocolate liquorice croissant marzipan. Carrot cake wafer cotton candy wafer donut souffl&eacute; souffl&eacute; icing. Cake jelly-o icing lemon drops. Chocolate jelly beans sugar plum. Brownie oat cake biscuit candy canes jelly. Liquorice tiramisu tootsie roll carrot cake sweet roll jelly beans fruitcake.</span></p>', N'Strawberry Daiquiri to cool you down in summer!', CAST(N'2016-04-25' AS Date), NULL, NULL, CAST(N'2016-04-26' AS Date))
GO
SET IDENTITY_INSERT [dbo].[BlogPosts] OFF
GO
SET IDENTITY_INSERT [dbo].[Tags] ON 

GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (1, N'Hamburger')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (2, N'Korean food')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (3, N'Ethiopian food')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (4, N'Japanese food')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (5, N'Fish')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (6, N'Sushi')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (7, N'BBQ')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (8, N'Meatzilla')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (9, N'Cake')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (10, N'Strawberry')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (11, N'Fruit cake')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (12, N'Noodles')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (13, N'Eggs')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (14, N'Cheese')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (15, N'Cocktail')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (16, N'Fish')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (17, N'Shrimp')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (18, N'Pizza')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (19, N'Italian food')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (20, N'Austrialian food')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (21, N'Soup')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (22, N'Pie')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (23, N'Stew')
GO
INSERT [dbo].[Tags] ([TagId], [Tag]) VALUES (24, N'Bomb Ass Ribz')
GO
SET IDENTITY_INSERT [dbo].[Tags] OFF
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (1, 1)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (2, 2)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (2, 7)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (2, 24)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (4, 9)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (4, 10)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (4, 11)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (6, 4)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (6, 5)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (6, 6)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (7, 3)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (8, 2)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (8, 12)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (10, 13)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (10, 14)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (12, 12)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (14, 16)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (14, 17)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (14, 23)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (16, 20)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (16, 22)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (18, 18)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (18, 19)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (19, 10)
GO
INSERT [dbo].[BlogPostsTags] ([BlogId], [TagId]) VALUES (19, 15)
GO
INSERT [dbo].[IdentityRole] ([RoleId], [Name]) VALUES (1, N'Admin')
GO
INSERT [dbo].[IdentityRole] ([RoleId], [Name]) VALUES (2, N'Contributor')
GO
INSERT [dbo].[IdentityRole] ([RoleId], [Name]) VALUES (3, N'User')
GO
INSERT [dbo].[IdentityUserRole] ([UserId], [RoleId]) VALUES (N'87e8fca7-c2fa-40d6-b9de-b226056455ac', 2)
GO
INSERT [dbo].[IdentityUserRole] ([UserId], [RoleId]) VALUES (N'd4cdc38c-5e60-4238-9c36-bbe39ec4e018', 2)
GO
INSERT [dbo].[IdentityProfile] ([UserId], [FirstName], [MiddleName], [LastName], [CreateBy], [CreateDate], [ModifyBy], [ModifyDate]) VALUES (N'87e8fca7-c2fa-40d6-b9de-b226056455ac', N'Jeane', NULL, N'Hong', N'00000000-0000-0000-0000-000000000000', CAST(N'2016-04-24 00:42:00' AS SmallDateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2016-04-24 00:42:00' AS SmallDateTime))
GO
INSERT [dbo].[IdentityProfile] ([UserId], [FirstName], [MiddleName], [LastName], [CreateBy], [CreateDate], [ModifyBy], [ModifyDate]) VALUES (N'd4cdc38c-5e60-4238-9c36-bbe39ec4e018', N'Chuck', NULL, N'Norris', N'00000000-0000-0000-0000-000000000000', CAST(N'2016-04-25 13:07:00' AS SmallDateTime), N'00000000-0000-0000-0000-000000000000', CAST(N'2016-04-25 13:07:00' AS SmallDateTime))
GO
