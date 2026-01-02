# NHS Patient Summary API

This repository contains a small ASP.NET Core Web API implemented as an exercise.

The focus of the exercise is clarity of intent, appropriate structure, and engineering judgement rather than scale or complexity.

---

## Overview

The API exposes a single endpoint to retrieve patient details by ID:

- GET /api/patients/{id}
- Returns **200 OK** with patient details when found  
- Returns **404 Not Found** when the patient does not exist  

For the purposes of the exercise, patient data is served from an in-memory source.

---

## Design notes

### API contract

The `PatientDto` type represents the public API response contract.

It is intentionally treated as a DTO rather than a domain or persistence model, keeping the API surface explicit and stable while leaving room for future internal models if the system were extended.

### In-memory data source

An in-memory patient service is used deliberately to match the scope of the exercise and keep the focus on API behaviour rather than infrastructure.

The service is accessed via an interface and registered through dependency injection, allowing the implementation to be swapped without impacting the API surface.

### Use of abstractions

No repository pattern, ORM, or persistence layer has been introduced.

Given the simplicity of the requirement (a read-only lookup backed by in-memory data), additional abstractions would add complexity without improving clarity. This decision is intentional rather than an omission.

### Operational considerations

Operational concerns such as global exception handling and structured logging (for example, via middleware or a logging framework like Serilog) are essential in production NHS systems. These have been intentionally excluded here to keep the exercise focused on core API behaviour. The service-oriented structure ensures they can be introduced later as cross-cutting concerns with minimal friction.

---

## Summary

This solution prioritises:

- clarity over complexity  
- intent over pattern-driven design  
- correctness over premature abstraction  

The implementation reflects how the API would be approached at the start of a real system, scaled appropriately to the scope of the exercise.
