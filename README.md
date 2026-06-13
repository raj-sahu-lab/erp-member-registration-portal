# Member Registration Portal — ERP System

A comprehensive web-based member registration and management system built for organizations to track members across geographic hierarchies with detailed profiling, reporting, and admin capabilities.

> **Note:** This is a 2014–2015 portfolio codebase. Authentication uses direct SQL queries (pre-parameterization era) and passwords are stored without modern hashing — these would be the first things hardened before any production deployment today.

## Built: 2012

## Tech Stack

- **Backend:** ASP.NET 3.5 (C#)
- **Database:** SQL Server
- **Frontend:** ASP.NET WebForms, AJAX Control Toolkit
- **Authentication:** Role-based (Admin / User)

## Features

### Admin Module
- **Full Member Registration** — 80+ fields covering personal, professional, organizational details
- **Geographic Hierarchy** — Country → State → District → Tehsil → City → Zone → Village
- **Organization Management** — Designations, levels, work areas, specializations
- **Multi-Dimensional Reporting** — By age, qualification, occupation, specialization, area, organization
- **User Credential Management** — Login/password administration
- **Work Assignment Tracking** — Task allocation across organizational hierarchy

### User Module
- View personal records
- Change password with security hints
- Upload profile data and documents

### Public Interface
- About Us, Services, FAQs, Contact
- Forgot ID / Password recovery via email

## Architecture

```
├── Admin/              — Admin pages with dedicated master page
├── User/               — User-facing pages
├── App_Code/           — Business logic (DB access, tree utilities)
├── Bin/                — Compiled assemblies
├── css/                — Stylesheets
├── js/                 — Client scripts
├── Img_Member/         — Member photos
├── Uploads/            — Document uploads
├── resume/             — Resume storage
└── web.config          — Configuration
```

## Setup

1. Create SQL Server database with required schema
2. Update `web.config` connection string with your credentials
3. Deploy to IIS with ASP.NET 3.5 enabled
4. Navigate to `Default.aspx` for login

## Note

Built as a production system for managing large-scale member registrations across multiple geographic regions. Handles thousands of member records with hierarchical organizational tracking.
