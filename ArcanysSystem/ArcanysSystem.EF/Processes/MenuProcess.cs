using ArcanysSystem.EF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ArcanysSystem.EF.Processes
{
    public class MenuProcess : IDisposable
    {
        public List<Menu> ListMenu { get; set; }

        public MenuProcess()
        {
            this.ListMenu = new List<Menu>();
        }

        public List<Menu> Get()
        {
            this.ListMenu.Clear();
            using (ArcanysOnlineEntities dbo = new ArcanysOnlineEntities())
            {
                using (DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var queries = from o in dbo.Menus
                                      select o;
                        foreach (var row in queries)
                        {
                            this.ListMenu.Add(new Menu
                            {
                                PageID = row.PageID,
                                PageName = row.PageName,
                                PageDescription = row.PageDescription,
                                PageURL = row.PageURL,
                                PageIcon = row.PageIcon,
                                isEnabled = row.isEnabled,
                                CreatedOn = row.CreatedOn,
                                CreatedBy = row.CreatedBy
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
            return this.ListMenu;
        }

        public List<Menu> Get(int id)
        {
            this.ListMenu.Clear();
            using (ArcanysOnlineEntities dbo = new ArcanysOnlineEntities())
            {
                using (DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        var queries = from o in dbo.Menus
                                      where o.PageID == id
                                      select o;
                        foreach (var row in queries)
                        {
                            this.ListMenu.Add(new Menu
                            {
                                PageID = row.PageID,
                                PageName = row.PageName,
                                PageDescription = row.PageDescription,
                                PageURL = row.PageURL,
                                PageIcon = row.PageIcon,
                                isEnabled = row.isEnabled,
                                CreatedOn = row.CreatedOn,
                                CreatedBy = row.CreatedBy
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
            return this.ListMenu;
        }

        public int Post(Menu model)
        {
            int affectedRows = 0;
            using (ArcanysOnlineEntities dbo = new ArcanysOnlineEntities())
            {
                using (DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        dbo.Menus.Add(model);
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

        public int Put(Menu model)
        {
            int affectedRows = 0;
            using (ArcanysOnlineEntities dbo = new ArcanysOnlineEntities())
            {
                using (DbContextTransaction transaction = dbo.Database.BeginTransaction(System.Data.IsolationLevel.ReadCommitted))
                {
                    try
                    {
                        Menu updateModel = dbo.Menus.Find(model.PageID);
                        updateModel.PageID = model.PageID;
                        updateModel.PageName = model.PageName;
                        updateModel.PageDescription = model.PageDescription;
                        updateModel.PageURL = model.PageURL;
                        updateModel.PageIcon = model.PageIcon;
                        updateModel.isEnabled = model.isEnabled;
                        updateModel.CreatedOn = model.CreatedOn;
                        updateModel.CreatedBy = model.CreatedBy;

                        dbo.Menus.Add(updateModel);
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
                        Menu deleteModel = dbo.Menus.Find(id);
                        dbo.Menus.Remove(deleteModel);
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
            this.ListMenu = null;
        }
    }
}