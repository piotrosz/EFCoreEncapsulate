﻿namespace EFCoreEncapsulate.Model;

public class CourseEnrollment
{
    public long Id { get; set; }
    public Grade Grade { get; set; }
    public virtual Course Course { get; set; }
    public virtual Student Student { get; set; }
}