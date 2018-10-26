using ArcanysSystem.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArcanysSystem.EF.Processes
{
    public class OnlineDriveProcess : IDisposable
    {
        public List<OnlineDrive> ListOnlineDrive { get; set; }

        public OnlineDriveProcess()
        {
            this.ListOnlineDrive = new List<OnlineDrive>();
        }

        public List<OnlineDrive> Get()
        {
            this.ListOnlineDrive.Clear();
            using (ArcanysOnlineEntities dbo = new ArcanysOnlineEntities())
            {
                using (DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var queries = from o in dbo.OnlineDrives
                                      select o;
                        foreach (var row in queries)
                        {
                            this.ListOnlineDrive.Add(new OnlineDrive
                            {
                                Id = row.Id,
                                FileNameGUID = row.FileNameGUID,
                                FileName = row.FileName,
                                FilePath = row.FilePath,
                                UploadedOn = row.UploadedOn,
                                UploadedBy = row.UploadedBy,
                                LastUpdatedOn = row.LastUpdatedOn,
                                LastUpdatedBy = row.LastUpdatedBy
                            });
                        }
                        //transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
                }
            }
            return this.ListOnlineDrive;
        }

        public List<OnlineDrive> Get(int id)
        {
            this.ListOnlineDrive.Clear();
            using (ArcanysOnlineEntities dbo = new ArcanysOnlineEntities())
            {
                using (DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var queries = from o in dbo.OnlineDrives
                                      where o.Id == id
                                      select o;
                        foreach (var row in queries)
                        {
                            this.ListOnlineDrive.Add(new OnlineDrive
                            {
                                Id = row.Id,
                                FileNameGUID = row.FileName,
                                FileName = row.FileName,
                                FilePath = row.FilePath,
                                UploadedOn = row.UploadedOn,
                                UploadedBy = row.UploadedBy,
                                LastUpdatedOn = row.LastUpdatedOn,
                                LastUpdatedBy = row.LastUpdatedBy
                            });
                        }
                        //transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
                }
            }
            return this.ListOnlineDrive;
        }

        public int Post(OnlineDrive model)
        {
            int affectedRows = 0;
            using (ArcanysOnlineEntities dbo = new ArcanysOnlineEntities())
            {
                using (DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        dbo.OnlineDrives.Add(model);
                        affectedRows = dbo.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
                }
            }
            return affectedRows;
        }

        public int Put(OnlineDrive model)
        {
            int affectedRows = 0;
            using (ArcanysOnlineEntities dbo = new ArcanysOnlineEntities())
            {
                using (DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        OnlineDrive updateModel = dbo.OnlineDrives.Find(model.Id);
                        updateModel.Id = model.Id;
                        updateModel.FileNameGUID = model.FileName;
                        updateModel.FileName = model.FileName;
                        updateModel.FilePath = model.FilePath;
                        updateModel.UploadedOn = model.UploadedOn;
                        updateModel.UploadedBy = model.UploadedBy;
                        updateModel.LastUpdatedOn = model.LastUpdatedOn;
                        updateModel.LastUpdatedBy = model.LastUpdatedBy;

                        dbo.OnlineDrives.Add(updateModel);
                        dbo.Entry(updateModel).State = System.Data.Entity.EntityState.Modified;
                        affectedRows = dbo.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
                }
            }
            return affectedRows;
        }

        public int Delete(int id)
        {
            int affectedRows = 0;
            using (ArcanysOnlineEntities dbo = new ArcanysOnlineEntities())
            {
                using (DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        OnlineDrive deleteModel = dbo.OnlineDrives.Find(id);
                        dbo.OnlineDrives.Remove(deleteModel);
                        affectedRows = dbo.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                    finally
                    {
                        transaction.Dispose();
                    }
                }
            }
            return affectedRows;
        }

        public void Dispose()
        {
            this.ReleaseObjects();
        }

        public void ReleaseObjects()
        {
            this.ListOnlineDrive = null;
        }
    }
}