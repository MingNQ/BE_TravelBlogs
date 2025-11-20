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