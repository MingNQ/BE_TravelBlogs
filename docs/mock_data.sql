INSERT INTO [Catalog].[Faqs] (Question, Answer, CreatedBy, CreatedOn, LastModifiedBy, LastModifiedOn, DeletedOn, DeletedBy) VALUES
('How do I book cheap flights?', 'Look for flights on Tuesdays, clear your browser cookies, and consider flying into alternative airports.', 1, '2024-03-15T10:00:00Z', 1, '2024-03-15T10:00:00Z', NULL, NULL),
('What are the best budget travel tips?', 'Cook your own meals, use public transport, and stay in hostels or guesthouses.', 12, '2024-01-22T08:30:00Z', 12, '2024-02-01T09:30:00Z', NULL, NULL), -- Được sửa sau khi tạo
('Do I need travel insurance?', 'Yes, it is highly recommended to cover medical emergencies, cancellations, and lost luggage.', 5, '2024-07-01T14:45:00Z', 5, '2024-07-01T14:45:00Z', NULL, NULL),
('How can I find local tour guides?', 'Check local tourism boards, use recommended apps, or ask hotel staff for genuine local suggestions.', 18, '2024-11-03T11:00:00Z', 18, '2024-11-03T11:00:00Z', NULL, NULL),
('What should I pack for a long trip?', 'Pack light! Focus on versatile clothing, essential toiletries, and a universal adapter.', 9, '2024-05-10T16:00:00Z', 9, '2024-05-11T16:10:00Z', NULL, NULL);

INSERT INTO [Catalog].[Categories] (Name, CreatedBy, CreatedOn, LastModifiedBy, LastModifiedOn, DeletedOn, DeletedBy) VALUES
('Asia Travel', 3, '2024-01-05T09:00:00Z', 3, '2024-01-05T09:00:00Z', NULL, NULL),
('Europe Backpacking', 15, '2024-02-14T11:00:00Z', 15, '2024-02-15T11:00:00Z', NULL, NULL),
('Budget Travel', 7, '2024-03-20T13:00:00Z', 7, '2024-03-20T13:00:00Z', NULL, NULL),
('Luxury Getaways', 1, '2024-04-01T15:00:00Z', 1, '2024-04-05T15:00:00Z', NULL, NULL),
('Travel Photography', 19, '2024-05-08T10:00:00Z', 19, '2024-05-08T10:00:00Z', NULL, NULL),
('Food & Cuisine', 10, '2024-06-12T09:30:00Z', 10, '2024-06-12T09:30:00Z', NULL, NULL),
('Solo Female Travel', 2, '2024-07-17T14:00:00Z', 2, '2024-07-20T14:00:00Z', NULL, NULL),
('Adventure Sports', 16, '2024-08-25T16:30:00Z', 16, '2024-08-25T16:30:00Z', NULL, NULL),
('Beach Destinations', 4, '2024-09-02T11:45:00Z', 4, '2024-09-03T11:45:00Z', NULL, NULL),
('Mountain Treks', 13, '2024-10-18T12:00:00Z', 13, '2024-10-18T12:00:00Z', NULL, NULL),
('Road Trips', 6, '2024-11-29T17:00:00Z', 6, '2024-12-01T17:00:00Z', NULL, NULL),
('City Guides', 17, '2024-01-28T09:00:00Z', 17, '2024-01-28T09:00:00Z', NULL, NULL),
('Visa & Documents', 8, '2024-02-09T10:00:00Z', 8, '2024-03-01T10:00:00Z', NULL, NULL),
('Digital Nomad Life', 14, '2024-04-22T11:00:00Z', 14, '2024-04-22T11:00:00Z', NULL, NULL),
('Responsible Tourism', 11, '2024-06-05T13:30:00Z', 11, '2024-06-05T13:30:00Z', NULL, NULL),
('USA National Parks', 20, '2024-08-01T08:00:00Z', 20, '2024-09-01T08:00:00Z', NULL, NULL),
('South America', 5, '2024-09-15T14:00:00Z', 5, '2024-09-15T14:00:00Z', NULL, NULL),
('Africa Safaris', 12, '2024-10-25T16:00:00Z', 12, '2024-10-25T16:00:00Z', NULL, NULL),
('Cruises', 9, '2024-11-11T12:30:00Z', 9, '2024-11-12T12:30:00Z', NULL, NULL),
('Weekend Getaways', 18, '2024-12-30T10:00:00Z', 18, '2024-12-30T10:00:00Z', NULL, NULL);

INSERT INTO [Catalog].[ContactsInformation] (Email, PhoneNumber, IsDefault, CreatedBy, CreatedOn, LastModifiedBy, LastModifiedOn, DeletedOn, DeletedBy) VALUES
('admin@travelblog.com', '+1 555-123-4567', 1, 3, '2024-01-01T08:00:00Z', 18, '2024-01-05T09:00:00Z', NULL, NULL),
('press@travelblog.com', '+44 20 7946 0958', 0, 15, '2024-02-10T10:00:00Z', 15, '2024-02-10T10:00:00Z', NULL, NULL),
('jobs@travelblog.com', '+61 2 8006 1234', 0, 7, '2024-03-05T11:00:00Z', 7, '2024-03-06T11:00:00Z', NULL, NULL),
('legal@travelblog.com', '+81 3-5555-1234', 0, 1, '2024-04-10T12:00:00Z', 1, '2024-04-10T12:00:00Z', NULL, NULL),
('partnerships@travelblog.com', '+33 1 40 00 00 00', 1, 19, '2024-05-01T13:00:00Z', 19, '2024-05-15T14:00:00Z', NULL, NULL),
('john.d@company.com', '+49 30 1234567', 0, 10, '2024-06-20T15:00:00Z', 10, '2024-06-20T15:00:00Z', NULL, NULL),
('maria.g@agency.net', '+34 91 123 45 67', 0, 2, '2024-07-07T16:00:00Z', 2, '2024-07-07T16:00:00Z', NULL, NULL),
('david.lee@pr.co', '+55 11 1234-5678', 0, 16, '2024-08-18T17:00:00Z', 16, '2024-08-18T17:00:00Z', NULL, NULL),
('contact9@mockdata.org', '+86 10 1234 5678', 0, 4, '2024-09-25T09:00:00Z', 4, '2024-09-30T10:00:00Z', NULL, NULL),
('contact10@mockdata.org', '+91 11 1234 5678', 0, 13, '2024-10-31T11:00:00Z', 13, '2024-10-31T11:00:00Z', NULL, NULL),
('contact11@mockdata.org', '+1 604 111 2222', 0, 6, '2024-01-20T13:00:00Z', 6, '2024-01-20T13:00:00Z', NULL, NULL),
('contact12@mockdata.org', '+65 6789 0123', 0, 17, '2024-02-25T14:00:00Z', 17, '2024-02-28T15:00:00Z', NULL, NULL),
('contact13@mockdata.org', '+66 2 123 4567', 0, 8, '2024-03-30T16:00:00Z', 8, '2024-03-30T16:00:00Z', NULL, NULL),
('contact50@mockdata.org', '+350 200 12345', 0, 11, '2024-12-10T20:00:00Z', 11, '2024-12-15T21:00:00Z', NULL, NULL);

INSERT INTO [Identity].[Users] (
    FirstName, LastName, UserName, NormalizedUserName, Email, NormalizedEmail, 
    PhoneNumber, PasswordHash, DateOfBirth, AvatarId, JoinDate, 
    IsVerifiedPhone, IsVerifiedEmail, CreatedBy, CreatedOn, LastModifiedBy, LastModifiedOn, DeletedOn, DeletedBy
)
VALUES
('John', 'Doe', 'john.doe', 'JOHN.DOE', 'john.doe@mail.com', 'JOHN.DOE@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Jane', 'Smith', 'jane.smith', 'JANE.SMITH', 'jane.smith@mail.com', 'JANE.SMITH@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Michael', 'Brown', 'michael.brown', 'MICHAEL.BROWN', 'michael.brown@mail.com', 'MICHAEL.BROWN@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Emily', 'Johnson', 'emily.johnson', 'EMILY.JOHNSON', 'emily.johnson@mail.com', 'EMILY.JOHNSON@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('David', 'Williams', 'david.williams', 'DAVID.WILLIAMS', 'david.williams@mail.com', 'DAVID.WILLIAMS@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Sarah', 'Miller', 'sarah.miller', 'SARAH.MILLER', 'sarah.miller@mail.com', 'SARAH.MILLER@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Chris', 'Davis', 'chris.davis', 'CHRIS.DAVIS', 'chris.davis@mail.com', 'CHRIS.DAVIS@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Laura', 'Garcia', 'laura.garcia', 'LAURA.GARCIA', 'laura.garcia@mail.com', 'LAURA.GARCIA@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('James', 'Martinez', 'james.martinez', 'JAMES.MARTINEZ', 'james.martinez@mail.com', 'JAMES.MARTINEZ@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Linda', 'Rodriguez', 'linda.rodriguez', 'LINDA.RODRIGUEZ', 'linda.rodriguez@mail.com', 'LINDA.RODRIGUEZ@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Robert', 'Wilson', 'robert.wilson', 'ROBERT.WILSON', 'robert.wilson@mail.com', 'ROBERT.WILSON@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Patricia', 'Moore', 'patricia.moore', 'PATRICIA.MOORE', 'patricia.moore@mail.com', 'PATRICIA.MOORE@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Daniel', 'Taylor', 'daniel.taylor', 'DANIEL.TAYLOR', 'daniel.taylor@mail.com', 'DANIEL.TAYLOR@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Barbara', 'Anderson', 'barbara.anderson', 'BARBARA.ANDERSON', 'barbara.anderson@mail.com', 'BARBARA.ANDERSON@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Paul', 'Thomas', 'paul.thomas', 'PAUL.THOMAS', 'paul.thomas@mail.com', 'PAUL.THOMAS@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Jennifer', 'Jackson', 'jennifer.jackson', 'JENNIFER.JACKSON', 'jennifer.jackson@mail.com', 'JENNIFER.JACKSON@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Steven', 'White', 'steven.white', 'STEVEN.WHITE', 'steven.white@mail.com', 'STEVEN.WHITE@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Karen', 'Harris', 'karen.harris', 'KAREN.HARRIS', 'karen.harris@mail.com', 'KAREN.HARRIS@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL),

('Matthew', 'Martin', 'matthew.martin', 'MATTHEW.MARTIN', 'matthew.martin@mail.com', 'MATTHEW.MARTIN@MAIL.COM', '', 
 'mJjVzTQ0VxiwJst3Ts7c1TqO+wrz+964YAj6BlE1rqzRyhUjC70kuF4wbGUlPQCXsQlqb4anBnGe9y3bbFJmDw==', NULL, NULL, GETUTCDATE(),
 0, 1, 1, GETUTCDATE(), 0, GETUTCDATE(), NULL, NULL);


INSERT INTO [Catalog].[Blogs] (
    Title, Description, Content, Rating, TimeRead, Status,
    AuthorId, CategoryId, DestinationId, ThumbnailId,
    CreatedBy, CreatedOn, LastModifiedBy, LastModifiedOn,
    DeletedOn, DeletedBy, ApproverId, RejectorId
)
VALUES
('Hidden waterfalls in Da Nang', 'Exploring beautiful hidden waterfalls for trekking lovers.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Da Nang has stunning remote waterfalls reachable by jungle trails."}}] }',
5, 8, 2, 1, 25, 12, 7, 76077, GETUTCDATE(), 76077, GETUTCDATE(), NULL, NULL, 1, NULL),

('A complete guide to Ha Long Bay cruise', 'Full guide for first-time cruise travelers in Ha Long Bay.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Best cruise routes, ticket types and must-visit spots in Ha Long Bay."}}] }',
4, 10, 1, 3, 34, 15, 10, 76059, GETUTCDATE(), 76059, GETUTCDATE(), NULL, NULL, NULL, 1),

('Best street food spots in Hue', 'Top cheap and delicious dishes you cannot miss in Hue.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Hue is well-known for unique local street food and night markets."}}] }',
5, 6, 3, 2, 28, 8, 4, 76088, GETUTCDATE(), 76088, GETUTCDATE(), NULL, NULL, 1, NULL),

('Sapa trekking itinerary 3 days', 'The perfect 3-day trekking plan for beginners in Sapa.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Sapa trails offer both scenic beauty and challenge."}}] }',
4, 7, 2, 1, 21, 9, 11, 76061, GETUTCDATE(), 76061, GETUTCDATE(), NULL, NULL, NULL, 1),

('Top 10 temples to visit in Hanoi', 'Historical temples in Hanoi you must explore.',
'{ "blocks":[{"type":"paragraph","data":{"text":"A mix of culture, religion and ancient architecture."}}] }',
5, 5, 2, 3, 39, 11, 3, 76055, GETUTCDATE(), 76055, GETUTCDATE(), NULL, NULL, 1, NULL),

('Discover Son Doong cave', 'Everything you need to know before visiting the world’s biggest cave.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Son Doong is a one-of-a-kind adventure destination."}}] }',
5, 11, 1, 2, 38, 16, 6, 76080, GETUTCDATE(), 76080, GETUTCDATE(), NULL, NULL, NULL, 1),

('Is Phu Quoc worth visiting during rainy season?', 'Pros and cons of traveling to Phu Quoc when it rains.',
'{ "blocks":[{"type":"paragraph","data":{"text":"What to expect and how to prepare for rainy weather in Phu Quoc."}}] }',
3, 7, 3, 1, 32, 18, 12, 76044, GETUTCDATE(), 76044, GETUTCDATE(), NULL, NULL, 1, NULL),

('Hoi An ancient town night market', 'Unforgettable night experience with lanterns and food.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Hoi An night market is colorful and vibrant."}}] }',
4, 6, 2, 3, 26, 13, 2, 76066, GETUTCDATE(), 76066, GETUTCDATE(), NULL, NULL, NULL, 1),

('Best diving spots in Nha Trang', 'Where to dive for the best coral reefs in Nha Trang.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Underwater views are incredible and the sea is crystal clear."}}] }',
5, 9, 2, 2, 30, 17, 5, 76059, GETUTCDATE(), 76059, GETUTCDATE(), NULL, NULL, 1, NULL),

('Vegan restaurants in Da Lat', 'A food guide for vegan travelers visiting Da Lat.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Healthy and Instagram-worthy vegan meals."}}] }',
4, 5, 1, 1, 29, 14, 10, 76071, GETUTCDATE(), 76071, GETUTCDATE(), NULL, NULL, NULL, 1),

('Adventure sports to try in Mui Ne', 'Top fun activities such as sand boarding and kitesurfing.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Mui Ne is a paradise for adventure lovers."}}] }',
5, 8, 2, 3, 21, 19, 1, 76059, GETUTCDATE(), 76059, GETUTCDATE(), NULL, NULL, 1, NULL),

('Where to stay in Da Nang – hotel guide', 'Best hotels sorted by price and view.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Da Nang has many beachfront and affordable hotels."}}] }',
3, 4, 3, 1, 35, 12, 7, 76050, GETUTCDATE(), 76050, GETUTCDATE(), NULL, NULL, NULL, 1),

('A weekend itinerary for Ninh Binh', '2-day plan to explore Ninh Binh.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Temples, limestone mountains and boat trips."}}] }',
4, 6, 2, 2, 27, 15, 4, 76033, GETUTCDATE(), 76033, GETUTCDATE(), NULL, NULL, 1, NULL),

('Must-try seafood in Cat Ba', 'Fresh seafood restaurants recommended by locals.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Cat Ba has incredible seafood with fair prices."}}] }',
5, 5, 1, 1, 22, 10, 9, 76064, GETUTCDATE(), 76064, GETUTCDATE(), NULL, NULL, NULL, 1),

('Hiking Ta Nang – Phan Dung trail', 'One of the most breathtaking hiking routes in Vietnam.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Ideal for professional hikers seeking adventure."}}] }',
4, 9, 2, 3, 39, 16, 8, 76078, GETUTCDATE(), 76078, GETUTCDATE(), NULL, NULL, 1, NULL),

('Coffee shops with views in Da Lat', 'Cafés surrounded by mountains and pine forests.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Perfect places for chilling and photo shooting."}}] }',
4, 3, 1, 2, 33, 14, 3, 76059, GETUTCDATE(), 76059, GETUTCDATE(), NULL, NULL, NULL, 1),

('What to pack for Vietnam trip', 'A packing checklist for first-time Vietnam travelers.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Items you should not forget when traveling across Vietnam."}}] }',
5, 7, 2, 1, 24, 13, 6, 76044, GETUTCDATE(), 76044, GETUTCDATE(), NULL, NULL, 1, NULL),

('Vietnam festivals you should join', 'Colorful traditional festivals across Vietnam.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Major festivals and their cultural meanings."}}] }',
4, 10, 2, 3, 26, 9, 2, 76088, GETUTCDATE(), 76088, GETUTCDATE(), NULL, NULL, NULL, 1),

('Nightlife in Ho Chi Minh City', 'Bars and clubs worth trying in HCMC.',
'{ "blocks":[{"type":"paragraph","data":{"text":"Nightlife in district 1 is energetic and lively."}}] }',
3, 5, 3, 2, 28, 18, 1, 76055, GETUTCDATE(), 76055, GETUTCDATE(), NULL, NULL, 1, NULL),

('Exploring the Mountains', NULL, '{"time":1763629708097,"blocks":[{"id":"b1","type":"paragraph","data":{"text":"A wonderful journey into the mountains."}}],"version":"2.31.0"}', NULL, NULL, 2, 5, 22, 30, 3, 1, GETUTCDATE(), 1, GETUTCDATE(), NULL, NULL, 1, NULL),
('City Lights and Nightlife', NULL, '{"time":1763694482218,"blocks":[{"id":"b2","type":"header","data":{"text":"Nightlife","level":2}},{"id":"b2p","type":"paragraph","data":{"text":"Exploring the city after dark."}}],"version":"2.31.0"}', NULL, NULL, 3, 6, 25, 32, 5, 2, GETUTCDATE(), 2, GETUTCDATE(), NULL, NULL, NULL, 1),
('Seaside Escape', NULL, '{"time":1763698076610,"blocks":[{"id":"b3","type":"header","data":{"text":"Beach Time","level":2}},{"id":"b3p","type":"paragraph","data":{"text":"Relaxing by the sea."}}],"version":"2.31.0"}', NULL, NULL, 2, 7, 29, 34, 6, 3, GETUTCDATE(), 3, GETUTCDATE(), NULL, NULL, 1, NULL),
('Cultural Heritage Tour', NULL, '{"time":1763698407633,"blocks":[{"id":"b4","type":"paragraph","data":{"text":"Discover local traditions and culture."}}],"version":"2.31.0"}', NULL, NULL, 3, 8, 24, 33, 4, 1, GETUTCDATE(), 1, GETUTCDATE(), NULL, NULL, NULL, 1),
('Gourmet Food Journey', NULL, '{"time":1763700000000,"blocks":[{"id":"b5","type":"paragraph","data":{"text":"Tasting the best local dishes."}}],"version":"2.31.0"}', NULL, NULL, 2, 9, 38, 31, 7, 2, GETUTCDATE(), 2, GETUTCDATE(), NULL, NULL, 1, NULL),
('Historic Landmarks', NULL, '{"time":1763701000000,"blocks":[{"id":"b6","type":"header","data":{"text":"History","level":2}},{"id":"b6p","type":"paragraph","data":{"text":"Visiting historic places and landmarks."}}],"version":"2.31.0"}', NULL, NULL, 3, 10, 27, 30, 1, 3, GETUTCDATE(), 3, GETUTCDATE(), NULL, NULL, NULL, 1),
('Adventure Sports', NULL, '{"time":1763702000000,"blocks":[{"id":"b7","type":"paragraph","data":{"text":"Thrilling adventure sports and activities."}}],"version":"2.31.0"}', NULL, NULL, 2, 11, 35, 28, 9, 1, GETUTCDATE(), 1, GETUTCDATE(), NULL, NULL, 1, NULL),
('Urban Exploration', NULL, '{"time":1763703000000,"blocks":[{"id":"b8","type":"header","data":{"text":"Urban Life","level":2}},{"id":"b8p","type":"paragraph","data":{"text":"Exploring the hidden parts of the city."}}],"version":"2.31.0"}', NULL, NULL, 3, 12, 39, 25, 10, 2, GETUTCDATE(), 2, GETUTCDATE(), NULL, NULL, NULL, 1),
('Nature Photography', NULL, '{"time":1763704000000,"blocks":[{"id":"b9","type":"paragraph","data":{"text":"Capturing nature’s beauty through the lens."}}],"version":"2.31.0"}', NULL, NULL, 2, 13, 26, 36, 8, 3, GETUTCDATE(), 3, GETUTCDATE(), NULL, NULL, 1, NULL),
('Local Festivals', NULL, '{"time":1763705000000,"blocks":[{"id":"b10","type":"header","data":{"text":"Festivals","level":2}},{"id":"b10p","type":"paragraph","data":{"text":"Enjoying local festivals and celebrations."}}],"version":"2.31.0"}', NULL, NULL, 3, 14, 21, 29, 2, 1, GETUTCDATE(), 1, GETUTCDATE(), NULL, NULL, NULL, 1),
('Mountain Hiking Tips', NULL, '{"time":1763706000000,"blocks":[{"id":"b11","type":"paragraph","data":{"text":"Best tips for mountain hiking."}}],"version":"2.31.0"}', NULL, NULL, 2, 15, 30, 37, 11, 2, GETUTCDATE(), 2, GETUTCDATE(), NULL, NULL, 1, NULL),
('City Markets Guide', NULL, '{"time":1763707000000,"blocks":[{"id":"b12","type":"header","data":{"text":"Markets","level":2}},{"id":"b12p","type":"paragraph","data":{"text":"Where to find the best city markets."}}],"version":"2.31.0"}', NULL, NULL, 3, 16, 23, 21, 12, 3, GETUTCDATE(), 3, GETUTCDATE(), NULL, NULL, NULL, 1),
('Coastal Roads Adventure', NULL, '{"time":1763708000000,"blocks":[{"id":"b13","type":"paragraph","data":{"text":"Driving along the scenic coastal roads."}}],"version":"2.31.0"}', NULL, NULL, 2, 17, 34, 32, 1, 1, GETUTCDATE(), 1, GETUTCDATE(), NULL, NULL, 1, NULL),
('Historic Museums', NULL, '{"time":1763709000000,"blocks":[{"id":"b14","type":"header","data":{"text":"Museums","level":2}},{"id":"b14p","type":"paragraph","data":{"text":"Visiting historic museums."}}],"version":"2.31.0"}', NULL, NULL, 3, 18, 28, 27, 2, 2, GETUTCDATE(), 2, GETUTCDATE(), NULL, NULL, NULL, 1),
('Gourmet Street Food', NULL, '{"time":1763710000000,"blocks":[{"id":"b15","type":"paragraph","data":{"text":"Tasting street food delicacies."}}],"version":"2.31.0"}', NULL, NULL, 2, 19, 37, 29, 3, 3, GETUTCDATE(), 3, GETUTCDATE(), NULL, NULL, 1, NULL),
('River Cruises', NULL, '{"time":1763711000000,"blocks":[{"id":"b16","type":"header","data":{"text":"Cruises","level":2}},{"id":"b16p","type":"paragraph","data":{"text":"Relaxing river cruises."}}],"version":"2.31.0"}', NULL, NULL, 3, 20, 22, 33, 4, 1, GETUTCDATE(), 1, GETUTCDATE(), NULL, NULL, NULL, 1),
('Desert Safari', NULL, '{"time":1763712000000,"blocks":[{"id":"b17","type":"paragraph","data":{"text":"Exciting desert safaris."}}],"version":"2.31.0"}', NULL, NULL, 2, 21, 31, 34, 5, 2, GETUTCDATE(), 2, GETUTCDATE(), NULL, NULL, 1, NULL),
('Island Hopping', NULL, '{"time":1763713000000,"blocks":[{"id":"b18","type":"header","data":{"text":"Islands","level":2}},{"id":"b18p","type":"paragraph","data":{"text":"Exploring beautiful islands."}}],"version":"2.31.0"}', NULL, NULL, 3, 22, 39, 30, 6, 3, GETUTCDATE(), 3, GETUTCDATE(), NULL, NULL, NULL, 1),
('Wine Tasting Tours', NULL, '{"time":1763714000000,"blocks":[{"id":"b19","type":"paragraph","data":{"text":"Enjoying local wine tasting tours."}}],"version":"2.31.0"}', NULL, NULL, 2, 23, 26, 28, 7, 1, GETUTCDATE(), 1, GETUTCDATE(), NULL, NULL, 1, NULL),
('Mountain Lakeside Relaxation', NULL, '{"time":1763714100000,"blocks":[{"id":"b20","type":"paragraph","data":{"text":"Relaxing by the mountain lake."}}],"version":"2.31.0"}', NULL, NULL, 2, 5, 35, 31, 8, 2, GETUTCDATE(), 2, GETUTCDATE(), NULL, NULL, 1, NULL),
('Sunset Beach Walks', NULL, '{"time":1763714200000,"blocks":[{"id":"b21","type":"paragraph","data":{"text":"Enjoying peaceful beach sunsets."}}],"version":"2.31.0"}', NULL, NULL, 3, 6, 23, 29, 9, 3, GETUTCDATE(), 3, GETUTCDATE(), NULL, NULL, NULL, 1),
('City Rooftop Bars', NULL, '{"time":1763714300000,"blocks":[{"id":"b22","type":"header","data":{"text":"Bars","level":2}},{"id":"b22p","type":"paragraph","data":{"text":"Best rooftop bars in the city."}}],"version":"2.31.0"}', NULL, NULL, 2, 7, 40, 32, 10, 1, GETUTCDATE(), 1, GETUTCDATE(), NULL, NULL, 1, NULL),
('Forest Hiking Trails', NULL, '{"time":1763714400000,"blocks":[{"id":"b23","type":"paragraph","data":{"text":"Top forest trails for hiking."}}],"version":"2.31.0"}', NULL, NULL, 3, 8, 26, 33, 1, 2, GETUTCDATE(), 2, GETUTCDATE(), NULL, NULL, NULL, 1),
('Local Coffee Shops', NULL, '{"time":1763714500000,"blocks":[{"id":"b24","type":"paragraph","data":{"text":"Best coffee shops around."}}],"version":"2.31.0"}', NULL, NULL, 2, 9, 22, 34, 2, 3, GETUTCDATE(), 3, GETUTCDATE(), NULL, NULL, 1, NULL),
('Historic Walking Tours', NULL, '{"time":1763714600000,"blocks":[{"id":"b25","type":"header","data":{"text":"Walking Tours","level":2}},{"id":"b25p","type":"paragraph","data":{"text":"Guided historic walking tours."}}],"version":"2.31.0"}', NULL, NULL, 3, 10, 28, 30, 3, 1, GETUTCDATE(), 1, GETUTCDATE(), NULL, NULL, NULL, 1),
('Night Markets Exploration', NULL, '{"time":1763714700000,"blocks":[{"id":"b26","type":"paragraph","data":{"text":"Experience vibrant night markets."}}],"version":"2.31.0"}', NULL, NULL, 2, 11, 39, 25, 4, 2, GETUTCDATE(), 2, GETUTCDATE(), NULL, NULL, 1, NULL),
('Countryside Biking', NULL, '{"time":1763714800000,"blocks":[{"id":"b27","type":"paragraph","data":{"text":"Bike through beautiful countryside."}}],"version":"2.31.0"}', NULL, NULL, 3, 12, 31, 29, 5, 3, GETUTCDATE(), 3, GETUTCDATE(), NULL, NULL, NULL, 1),
('Art Galleries Visit', NULL, '{"time":1763714900000,"blocks":[{"id":"b28","type":"header","data":{"text":"Art Galleries","level":2}},{"id":"b28p","type":"paragraph","data":{"text":"Exploring local art galleries."}}],"version":"2.31.0"}', NULL, NULL, 2, 13, 37, 32, 6, 1, GETUTCDATE(), 1, GETUTCDATE(), NULL, NULL, 1, NULL),
('Weekend Getaways', NULL, '{"time":1763715000000,"blocks":[{"id":"b29","type":"paragraph","data":{"text":"Perfect weekend trip ideas."}}],"version":"2.31.0"}', NULL, NULL, 3, 14, 23, 33, 7, 2, GETUTCDATE(), 2, GETUTCDATE(), NULL, NULL, NULL, 1),
('Street Art Tours', NULL, '{"time":1763715100000,"blocks":[{"id":"b30","type":"paragraph","data":{"text":"Discovering street art around the city."}}],"version":"2.31.0"}', NULL, NULL, 2, 15, 26, 34, 8, 3, GETUTCDATE(), 3, GETUTCDATE(), NULL, NULL, 1, NULL),
('Bird Watching Spots', NULL, '{"time":1763715200000,"blocks":[{"id":"b31","type":"header","data":{"text":"Bird Watching","level":2}},{"id":"b31p","type":"paragraph","data":{"text":"Top spots for bird watching."}}],"version":"2.31.0"}', NULL, NULL, 3, 16, 21, 30, 9, 1, GETUTCDATE(), 1, GETUTCDATE(), NULL, NULL, NULL, 1),
('Local Theater Shows', NULL, '{"time":1763715300000,"blocks":[{"id":"b32","type":"paragraph","data":{"text":"Enjoying local theater performances."}}],"version":"2.31.0"}', NULL, NULL, 2, 17, 38, 29, 10, 2, GETUTCDATE(), 2, GETUTCDATE(), NULL, NULL, 1, NULL),
('Fishing Trips', NULL, '{"time":1763715400000,"blocks":[{"id":"b33","type":"paragraph","data":{"text":"Best fishing spots and tips."}}],"version":"2.31.0"}', NULL, NULL, 3, 18, 25, 31, 11, 3, GETUTCDATE(), 3, GETUTCDATE(), NULL, NULL, NULL, 1),
('Hot Springs Visits', NULL, '{"time":1763715500000,"blocks":[{"id":"b34","type":"header","data":{"text":"Hot Springs","level":2}},{"id":"b34p","type":"paragraph","data":{"text":"Relaxing in hot springs."}}],"version":"2.31.0"}', NULL, NULL, 2, 19, 27, 28, 1, 1, GETUTCDATE(), 1, GETUTCDATE(), NULL, NULL, 1, NULL),
('Mountain Bike Trails', NULL, '{"time":1763715600000,"blocks":[{"id":"b35","type":"paragraph","data":{"text":"Exciting mountain bike trails."}}],"version":"2.31.0"}', NULL, NULL, 3, 20, 36, 30, 2, 2, GETUTCDATE(), 2, GETUTCDATE(), NULL, NULL, NULL, 1),
('Local Music Festivals', NULL, '{"time":1763715700000,"blocks":[{"id":"b36","type":"header","data":{"text":"Music Festivals","level":2}},{"id":"b36p","type":"paragraph","data":{"text":"Celebrating local music."}}],"version":"2.31.0"}', NULL, NULL, 2, 21, 24, 33, 3, 3, GETUTCDATE(), 3, GETUTCDATE(), NULL, NULL, 1, NULL),
('Winter Ski Trips', NULL, '{"time":1763715800000,"blocks":[{"id":"b37","type":"paragraph","data":{"text":"Best ski trips in winter."}}],"version":"2.31.0"}', NULL, NULL, 3, 22, 30, 29, 4, 1, GETUTCDATE(), 1, GETUTCDATE(), NULL, NULL, NULL, 1),
('Farmers Market Finds', NULL, '{"time":1763715900000,"blocks":[{"id":"b38","type":"paragraph","data":{"text":"Fresh finds at farmers markets."}}],"version":"2.31.0"}', NULL, NULL, 2, 23, 39, 28, 5, 2, GETUTCDATE(), 2,GETUTCDATE(), NULL, NULL, NULL, 1)
