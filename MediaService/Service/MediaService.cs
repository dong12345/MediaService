using MediaService.Common;
using MediaService.DBModel;
using MediaService.MediaDBContext;
using MediaService.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MediaService.Service
{
    public class MediaServices
    {
        private DbContextOptionsBuilder<MyContext> _options;
        private int count = 0;
        private string msg = string.Empty;
        private bool isSuccess = false;
        public MediaServices(DbContextOptionsBuilder<MyContext> options, string _sql)
        {
            _options = options;
            options.UseNpgsql(_sql);
        }



        #region FormPublic(会刊)

        /// <summary>
        /// 创建会刊
        /// </summary>
        /// <returns></returns>
        public async Task<ModifyReplyModel> CreateFormPublicInfo(FormPublic formPublic)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    await _context.FormPublic.AddAsync(formPublic);
                    count = await _context.SaveChangesAsync();
                    if (count > 0)
                    {
                        msg = "创建成功";
                        isSuccess = true;
                    }
                    else
                    {
                        msg = "创建失败";
                        isSuccess = false;
                    }

                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.InnerException.Message, count);
            }
        }

        /// <summary>
        /// 修改会刊信息
        /// </summary>
        /// <param name="formPublic"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> UpdateFormPublicInfo(FormPublic formPublic)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var modified_model = await _context.FormPublic.FirstOrDefaultAsync(x => x.Id == formPublic.Id);
                    if (modified_model == null)
                    {
                        msg = "当前实例不存在";
                        count = 0;
                        isSuccess = false;
                    }
                    else
                    {
                        #region 修改
                        modified_model.Address = formPublic.Address;
                        modified_model.AddressEn = formPublic.AddressEn;
                        modified_model.BoothNumber = formPublic.BoothNumber;
                        modified_model.CompanyId = formPublic.CompanyId;
                        modified_model.CompanyNameCn = formPublic.CompanyNameCn;
                        modified_model.CompanyNameEn = formPublic.CompanyNameEn;
                        modified_model.Description = formPublic.Description;
                        modified_model.DescriptionEn = formPublic.DescriptionEn;
                        modified_model.Email = formPublic.Email;
                        modified_model.Fax = formPublic.Fax;
                        modified_model.IsHaveLogo = formPublic.IsHaveLogo;
                        modified_model.IsPay = formPublic.IsPay;
                        modified_model.Option = formPublic.Option;
                        modified_model.Logo = formPublic.Logo;
                        modified_model.OwnerId = formPublic.OwnerId;
                        modified_model.OwnerName = formPublic.OwnerName;
                        modified_model.PavilionNumber = formPublic.PavilionNumber;
                        modified_model.SnecLogoWebsite = formPublic.SnecLogoWebsite;
                        modified_model.Telephone = formPublic.Telephone;
                        modified_model.Website = formPublic.Website;
                        modified_model.UpdatedAt = formPublic.UpdatedAt;
                        modified_model.ProductType = formPublic.ProductType;
                        modified_model.Source = formPublic.Source;
                        #endregion
                        count = await _context.SaveChangesAsync();
                        isSuccess = true;
                        msg = "修改成功";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据Id删除会刊信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> DeleteFormPublicInfoById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var gid = new Guid(id);
                    var model = await _context.FormPublic.FirstOrDefaultAsync(x => x.Id == gid);
                    if (model == null)
                    {
                        msg = "数据库中没有id为" + id + "的实例可以删除！";
                        count = 0;
                        isSuccess = false;
                    }
                    else
                    {
                        _context.FormPublic.Remove(model);
                        count = await _context.SaveChangesAsync();
                        if (count > 0)
                        {
                            msg = "删除成功";
                            isSuccess = true;
                        }
                        else
                        {
                            msg = "删除失败";
                            isSuccess = false;
                        }
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }


        /// <summary>
        /// 获得会刊信息列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<FormPublic>> GetFormPublicInfoList()
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var list = await _context.FormPublic.ToListAsync();
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据Id获得会刊信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<FormPublic> GetFormPublicInfoById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    Guid gid = new Guid(id);
                    var item = await _context.FormPublic
                            .FirstOrDefaultAsync(x => x.Id == gid);
                    return item;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据条件查询会刊信息列表(带分页)
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<List<FormPublic>> GetFormPublicList(int pageindex, int pagesize, SearchModel searchModel)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {

                    if (searchModel == null)
                    {
                        var list = await _context.FormPublic
                                .OrderByDescending(x => x.CreatedAt)
                                .Skip(((pageindex - 1) * pagesize))
                                .Take(pagesize)
                                .ToListAsync();
                        return list;
                    }
                    else
                    {
                        var list = await _context.FormPublic
                                     .Where(x => (string.IsNullOrEmpty(searchModel.CompanyName) || x.CompanyNameCn.Contains(searchModel.CompanyName) || x.CompanyNameEn.Contains(searchModel.CompanyName))
                                    && (string.IsNullOrEmpty(searchModel.ContractNumber) || x.ContractNumber.Contains(searchModel.ContractNumber))
                                    && (string.IsNullOrEmpty(searchModel.PavilionNumber) || x.PavilionNumber.Contains(searchModel.PavilionNumber))
                                    && (string.IsNullOrEmpty(searchModel.BoothNumber) || x.BoothNumber.Contains(searchModel.BoothNumber))
                                    && (string.IsNullOrEmpty(searchModel.IsPay) || DataHelper.GetBool(searchModel.IsPay) == x.IsPay)
                                    && (string.IsNullOrEmpty(searchModel.OwnerId) || x.OwnerId == searchModel.OwnerId)
                                    && (string.IsNullOrEmpty(searchModel.IsHaveLogo) || x.IsHaveLogo == DataHelper.GetBool(searchModel.IsHaveLogo))
                                    && (string.IsNullOrEmpty(searchModel.Begin_date) || x.CreatedAt >= Convert.ToDateTime(searchModel.Begin_date))
                                    && (string.IsNullOrEmpty(searchModel.End_date) || x.CreatedAt <= Convert.ToDateTime(searchModel.Begin_date)))
                                   .OrderByDescending(x => x.CreatedAt)
                                   .Skip(((pageindex - 1) * pagesize))
                                   .Take(pagesize)
                                   .ToListAsync();
                        return list;
                    }

                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据条件查询会刊信息总数
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<int> GetFormPublicListCount(SearchModel searchModel)
        {
            var total = 0;
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var list = await _context.FormPublic.ToListAsync();
                    if (searchModel != null)
                    {
                        total = list
                           .Where(x => (string.IsNullOrEmpty(searchModel.CompanyName) || x.CompanyNameCn.Contains(searchModel.CompanyName) || x.CompanyNameEn.Contains(searchModel.CompanyName))
                                    && (string.IsNullOrEmpty(searchModel.ContractNumber) || x.ContractNumber.Contains(searchModel.ContractNumber))
                                    && (string.IsNullOrEmpty(searchModel.PavilionNumber) || x.PavilionNumber.Contains(searchModel.PavilionNumber))
                                    && (string.IsNullOrEmpty(searchModel.BoothNumber) || x.BoothNumber.Contains(searchModel.BoothNumber))
                                    && (string.IsNullOrEmpty(searchModel.IsPay) || DataHelper.GetBool(searchModel.IsPay) == x.IsPay)
                                    && (string.IsNullOrEmpty(searchModel.OwnerId) || x.OwnerId == searchModel.OwnerId)
                                    && (string.IsNullOrEmpty(searchModel.Begin_date) || x.CreatedAt >= Convert.ToDateTime(searchModel.Begin_date))
                                    && (string.IsNullOrEmpty(searchModel.End_date) || x.CreatedAt <= Convert.ToDateTime(searchModel.Begin_date)))
                            .Count();
                    }
                    else
                    {
                        total = list.Count();
                    }
                }


            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
            return total;
        }

        /// <summary>
        /// 根据展商合同Id获得会刊信息
        /// </summary>
        /// <param name="exbContractId"></param>
        /// <returns></returns>
        public async Task<FormPublic> getFormPublicInfoByCondition(ExbContractConditionModel where)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var item = await _context.FormPublic
                            .FirstOrDefaultAsync(x => (x.ExbContractId == where.ExbContractId && x.Source==where.Source));
                    return item;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据展商合同Id判断新增或修改会刊信息
        /// </summary>
        /// <param name="formPublic"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> OperateFormPublicInfoByExbContractId(FormPublic formPublic)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var contractId = formPublic.ExbContractId;
                    var source = formPublic.Source;
                    //根据展商合同Id查询对应会刊是否存在;若存在,修改;否则,新增;
                    var model = await _context.FormPublic.FirstOrDefaultAsync(x => (x.ExbContractId == formPublic.ExbContractId && x.Source==source));
                    if (model != null)
                    {
                        //修改
                        #region 修改
                        model.Address = formPublic.Address;
                        model.AddressEn = formPublic.AddressEn;
                        model.BoothNumber = formPublic.BoothNumber;
                        model.CompanyId = formPublic.CompanyId;
                        model.CompanyNameCn = formPublic.CompanyNameCn;
                        model.CompanyNameEn = formPublic.CompanyNameEn;
                        model.Description = formPublic.Description;
                        model.DescriptionEn = formPublic.DescriptionEn;
                        model.Email = formPublic.Email;
                        model.Fax = formPublic.Fax;
                        model.IsHaveLogo = formPublic.IsHaveLogo;
                        model.IsPay = formPublic.IsPay;
                        model.Option = formPublic.Option;
                        model.Logo = formPublic.Logo;
                        model.OwnerId = formPublic.OwnerId;
                        model.OwnerName = formPublic.OwnerName;
                        model.PavilionNumber = formPublic.PavilionNumber;
                        model.SnecLogoWebsite = formPublic.SnecLogoWebsite;
                        model.Telephone = formPublic.Telephone;
                        model.Website = formPublic.Website;
                        model.UpdatedAt = DateTime.Now;
                        model.ProductType = formPublic.ProductType;
                        model.Source = formPublic.Source;
                        #endregion
                        count = await _context.SaveChangesAsync();
                        isSuccess = true;
                        msg = "修改成功";

                    }
                    else
                    {
                        //新增
                        formPublic.CreatedAt = DateTime.Now;
                        await _context.FormPublic.AddAsync(formPublic);
                        count = await _context.SaveChangesAsync();
                        if (count > 0)
                        {
                            msg = "创建成功";
                            isSuccess = true;
                        }
                        else
                        {
                            msg = "创建失败";
                            isSuccess = false;
                        }

                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        #endregion

        #region Express(快递单)

        /// <summary>
        /// 创建快递单记录
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> CreateExpressInfo(Express express)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    await _context.Express.AddAsync(express);
                    count = await _context.SaveChangesAsync();
                    if (count > 0)
                    {
                        isSuccess = true;
                        msg = "创建成功";
                    }
                    else
                    {
                        msg = "创建失败";
                        isSuccess = false;
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 修改快递单记录
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> UpdateExpressInfo(Express express)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var model = await _context.Express.FirstOrDefaultAsync(x => x.Id == express.Id);
                    if (model == null)
                    {
                        msg = "当前实例不存在";
                        isSuccess = false;
                        count = 0;
                    }
                    else
                    {
                        model.Address = express.Address;
                        model.ExpressCompany = express.ExpressCompany;
                        model.ExpressContent = express.ExpressContent;
                        model.ExpressNum = express.ExpressNum;
                        model.IsExamine = express.IsExamine;
                        model.IsSend = express.IsSend;
                        model.Price = express.Price;
                        model.Recipient = express.Recipient;
                        model.RecipientUnit = express.RecipientUnit;
                        model.Sender = express.Sender;
                        model.SentDate = express.SentDate;
                        model.Tel = express.Tel;
                        model.UpdatedAt = express.UpdatedAt;
                        model.Year = express.Year;
                        model.IsExhibitor = express.IsExhibitor;

                        count = await _context.SaveChangesAsync();
                        isSuccess = true;
                        msg = "修改成功";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }


        /// <summary>
        /// 根据Id删除快递单记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> DeleteExpressInfoById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var gid = new Guid(id);
                    var model = await _context.Express.FirstOrDefaultAsync(x => x.Id == gid);
                    if (model == null)
                    {
                        msg = "数据库中没有id为" + id + "的实例可以删除！";
                        isSuccess = false;
                        count = 0;
                    }
                    else
                    {
                        _context.Express.Remove(model);
                        count = await _context.SaveChangesAsync();
                        if (count > 0)
                        {
                            msg = "删除成功";
                            isSuccess = true;
                        }
                        else
                        {
                            msg = "删除失败";
                            isSuccess = false;
                        }
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据Id获得快递单信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Express> GetExpressInfoById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    Guid gid = new Guid(id);
                    var item = await _context.Express
                            .FirstOrDefaultAsync(x => x.Id == gid);
                    return item;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据条件查询快递单信息列表(带分页)
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<List<Express>> GetExpressList(int pageindex, int pagesize, SearchModel searchModel)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    if (searchModel == null)
                    {
                        var list = await _context.Express
                                 .OrderByDescending(x => x.CreatedAt)
                                 .Skip(((pageindex - 1) * pagesize))
                                 .Take(pagesize)
                                 .ToListAsync();

                        return list;
                    }
                    else
                    {
                        var list = await _context.Express
                                .Where(x => (string.IsNullOrEmpty(searchModel.ExpressNum) || x.ExpressNum.Contains(searchModel.ExpressNum))
                                 && (string.IsNullOrEmpty(searchModel.Sender) || x.Sender.Contains(searchModel.Sender))
                                 && (string.IsNullOrEmpty(searchModel.Begin_date) || x.SentDate >= Convert.ToDateTime(searchModel.Begin_date))
                                 && (string.IsNullOrEmpty(searchModel.End_date) || x.SentDate <= Convert.ToDateTime(searchModel.End_date))
                                 && (string.IsNullOrEmpty(searchModel.Recipient) || x.Recipient.Contains(searchModel.Recipient))
                                 && (string.IsNullOrEmpty(searchModel.RecipientUnit) || x.RecipientUnit.Contains(searchModel.RecipientUnit)))
                                 .OrderByDescending(x => x.CreatedAt)
                                 .Skip(((pageindex - 1) * pagesize))
                                 .Take(pagesize)
                                 .ToListAsync();

                        return list;
                    }

                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }


        /// <summary>
        /// 根据条件查询快递单信息总数
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<int> GetExpressListCount(SearchModel searchModel)
        {
            var total = 0;
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    if (searchModel != null)
                    {
                        var list = await _context.Express
                            .Where(x => (string.IsNullOrEmpty(searchModel.ExpressNum) || x.ExpressNum.Contains(searchModel.ExpressNum))
                        && (string.IsNullOrEmpty(searchModel.Sender) || x.Sender.Contains(searchModel.Sender))
                        && (string.IsNullOrEmpty(searchModel.Begin_date) || x.SentDate >= Convert.ToDateTime(searchModel.Begin_date))
                        && (string.IsNullOrEmpty(searchModel.End_date) || x.SentDate <= Convert.ToDateTime(searchModel.End_date))
                        && (string.IsNullOrEmpty(searchModel.Recipient) || x.Recipient.Contains(searchModel.Recipient))
                        && (string.IsNullOrEmpty(searchModel.RecipientUnit) || x.RecipientUnit.Contains(searchModel.RecipientUnit)))
                        .ToListAsync();
                        total = list.Count();
                    }
                    else
                    {
                        var list = await _context.Express.ToListAsync();
                        total = list.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
            return total;
        }
        #endregion

        #region CatalogueBooks(web页面会刊订购信息)

        /// <summary>
        /// 创建会刊订购信息
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> CreateCatalogueBooksInfo(CatalogueBooks cb)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    await _context.CatalogueBooks.AddAsync(cb);
                    count = await _context.SaveChangesAsync();
                    if (count > 0)
                    {
                        isSuccess = true;
                        msg = "创建成功";
                    }
                    else
                    {
                        isSuccess = false;
                        msg = "创建失败";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 修改会刊订购信息
        /// </summary>
        /// <param name="cb"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> UpdateCatalogueBooksInfo(CatalogueBooks cb)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var model = await _context.CatalogueBooks.FirstOrDefaultAsync(x => x.Id == cb.Id);
                    if (model == null)
                    {
                        msg = "当前实例不存在";
                        isSuccess = false;
                        count = 0;
                    }
                    else
                    {
                        model.Address = cb.Address;
                        model.Count = cb.Count;
                        model.Country = cb.Country;
                        model.Des = cb.Des;
                        model.Email = cb.Email;
                        model.Name = cb.Name;
                        model.Tel = cb.Tel;
                        model.Type = cb.Type;
                        model.UpdatedAt = cb.UpdatedAt;

                        count = await _context.SaveChangesAsync();
                        isSuccess = true;
                        msg = "修改成功";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据Id删除会刊订购信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> DeleteCatalogueBooksById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var gid = new Guid(id);
                    var model = await _context.CatalogueBooks.FirstOrDefaultAsync(x => x.Id == gid);
                    if (model == null)
                    {
                        msg = "数据库中没有id为" + id + "的实例可以删除！";
                        isSuccess = false;
                        count = 0;
                    }
                    else
                    {
                        _context.CatalogueBooks.Remove(model);
                        count = await _context.SaveChangesAsync();
                        if (count > 0)
                        {
                            msg = "删除成功";
                            isSuccess = true;
                        }
                        else
                        {
                            msg = "删除失败";
                            isSuccess = false;
                        }
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据Id获得会刊订购信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<CatalogueBooks> GetCatalogueBooksById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    Guid gid = new Guid(id);
                    var item = await _context.CatalogueBooks
                            .FirstOrDefaultAsync(x => x.Id == gid);
                    return item;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据条件查询会刊订购信息列表(带分页)
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<List<CatalogueBooks>> GetCatalogueBooksList(int pageindex, int pagesize, SearchModel searchModel)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    if (searchModel == null)
                    {
                        var list = await _context.CatalogueBooks
                             .OrderByDescending(x => x.CreatedAt)
                             .Skip(((pageindex - 1) * pagesize))
                             .Take(pagesize)
                             .ToListAsync();
                        return list;

                    }
                    else
                    {
                        var list = await _context.CatalogueBooks
                                    .Where(x => (string.IsNullOrEmpty(searchModel.Type) || x.Type.Contains(searchModel.Type))
                                     && (string.IsNullOrEmpty(searchModel.Name) || x.Name.Contains(searchModel.Name))
                                     && (string.IsNullOrEmpty(searchModel.Email) || x.Email.Contains(searchModel.Email)))
                                     .OrderByDescending(x => x.CreatedAt)
                                     .Skip(((pageindex - 1) * pagesize))
                                     .Take(pagesize)
                                     .ToListAsync();
                        return list;
                    }


                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据条件查询会刊订购信息列表总数
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<int> GetCatalogueBooksListCount(SearchModel searchModel)
        {
            var total = 0;
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    if (searchModel != null)
                    {
                        var list = await _context.CatalogueBooks
                            .Where(x => (string.IsNullOrEmpty(searchModel.Type) || x.Type.Contains(searchModel.Type))
                       && (string.IsNullOrEmpty(searchModel.Name) || x.Name.Contains(searchModel.Name))
                       && (string.IsNullOrEmpty(searchModel.Email) || x.Email.Contains(searchModel.Email)))
                        .ToListAsync();
                        total = list.Count();
                    }
                    else
                    {
                        var list = await _context.CatalogueBooks.ToListAsync();
                        total = list.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
            return total;
        }
        #endregion


        #region Interview(专题采访)

        /// <summary>
        /// 创建专题采访信息
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> CreateInterviewInfo(Interview interview)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    await _context.Interview.AddAsync(interview);
                    count = await _context.SaveChangesAsync();
                    if (count > 0)
                    {
                        isSuccess = true;
                        msg = "创建成功";
                    }
                    else
                    {
                        isSuccess = false;
                        msg = "创建失败";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }


        /// <summary>
        /// 修改专题采访信息
        /// </summary>
        /// <param name="interview"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> UpdateInterviewInfo(Interview interview)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var model = await _context.Interview.FirstOrDefaultAsync(x => x.Id == interview.Id);
                    if (model == null)
                    {
                        msg = "当前实例不存在";
                        isSuccess = false;
                        count = 0;
                    }
                    else
                    {
                        model.InterviewTime = interview.InterviewTime;
                        model.Introduction = interview.Introduction;
                        model.JobTitle = interview.JobTitle;
                        model.JobTitleEn = interview.JobTitleEn;
                        model.MediaName = interview.MediaName;
                        model.Name = interview.Name;
                        model.NameEn = interview.NameEn;
                        model.Photo = interview.Photo;
                        model.CompanyName = interview.CompanyName;
                        model.CompanyNameEn = interview.CompanyNameEn;
                        model.UpdatedAt = interview.UpdatedAt;
                        model.Year = interview.Year;
                        model.Website = interview.Website;

                        count = await _context.SaveChangesAsync();
                        isSuccess = true;
                        msg = "修改成功";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据Id删除专题采访信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> DeleteInterviewById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var gid = new Guid(id);
                    var model = await _context.Interview.FirstOrDefaultAsync(x => x.Id == gid);
                    if (model == null)
                    {
                        msg = "数据库中没有id为" + id + "的实例可以删除！";
                        isSuccess = false;
                        count = 0;
                    }
                    else
                    {
                        _context.Interview.Remove(model);
                        count = await _context.SaveChangesAsync();
                        if (count > 0)
                        {
                            msg = "删除成功";
                            isSuccess = true;
                        }
                        else
                        {
                            msg = "删除失败";
                            isSuccess = false;
                        }
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }


        /// <summary>
        /// 根据Id获得专题采访信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Interview> GetInterviewInfoById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    Guid gid = new Guid(id);
                    var item = await _context.Interview
                            .FirstOrDefaultAsync(x => x.Id == gid);
                    return item;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据exbContractID获得专题采访信息
        /// </summary>
        /// <param name="exbContractId"></param>
        /// <returns></returns>
        public async Task<Interview> GetInterviewInfoByExbContractId(string exbContractId)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var item = await _context.Interview
                            .FirstOrDefaultAsync(x => x.ExbContractId == exbContractId);
                    return item;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }


        /// <summary>
        /// 根据条件查询专题采访信息列表(带分页)
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<List<Interview>> GetInterviewList(int pageindex, int pagesize, SearchModel searchModel)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    if (searchModel == null)
                    {
                        var list = await _context.Interview
                                .OrderByDescending(x => x.CreatedAt)
                                .Skip(((pageindex - 1) * pagesize))
                                .Take(pagesize)
                                .ToListAsync();
                        return list;
                    }
                    else
                    {
                        var list = await _context.Interview
                                 .Where(x => (string.IsNullOrEmpty(searchModel.CompanyName) || x.CompanyName.Contains(searchModel.CompanyName) || x.CompanyNameEn.Contains(searchModel.CompanyName))
                                        && (string.IsNullOrEmpty(searchModel.OwnerId) || x.OwnerId == searchModel.OwnerId)
                                        && (string.IsNullOrEmpty(searchModel.Year) || x.Year==searchModel.Year)
                                        && (string.IsNullOrEmpty(searchModel.Website) || x.Website==searchModel.Website))
                                .OrderByDescending(x => x.CreatedAt)
                                .Skip(((pageindex - 1) * pagesize))
                                .Take(pagesize)
                                .ToListAsync();
                        return list;
                    }



                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据条件查询专题采访信息总数
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<int> GetInterviewListCount(SearchModel searchModel)
        {
            var total = 0;
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    if (searchModel != null)
                    {
                        var list = await _context.Interview
                        .Where(x => (string.IsNullOrEmpty(searchModel.CompanyName) || x.CompanyName.Contains(searchModel.CompanyName) || x.CompanyNameEn.Contains(searchModel.CompanyName))
                        && (string.IsNullOrEmpty(searchModel.OwnerId) || x.OwnerId == searchModel.OwnerId)
                        && (string.IsNullOrEmpty(searchModel.Year) || x.Year == searchModel.Year)
                        && (string.IsNullOrEmpty(searchModel.Website) || x.Website == searchModel.Website))
                        .ToListAsync();
                        total = list.Count();
                    }
                    else
                    {
                        var list = await _context.Interview.ToListAsync();
                        total = list.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
            return total;
        }
        #endregion


        #region HighlightsInfo(十大亮点)

        /// <summary>
        /// 创建十大亮点信息
        /// </summary>
        /// <param name="highlightsInfo"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> CreateHighlightsInfo(HighlightsInfo highlightsInfo)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    await _context.HighlightsInfo.AddAsync(highlightsInfo);
                    count = await _context.SaveChangesAsync();
                    if (count > 0)
                    {
                        isSuccess = true;
                        msg = "创建成功";
                    }
                    else
                    {
                        isSuccess = false;
                        msg = "创建失败";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 修改十大亮点信息
        /// </summary>
        /// <param name="highlightsInfo"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> UpdateHighlightsInfo(HighlightsInfo highlightsInfo)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var model = await _context.HighlightsInfo.FirstOrDefaultAsync(x => x.Id == highlightsInfo.Id);
                    if (model == null)
                    {
                        isSuccess = false;
                        msg = "当前实例不存在";
                        count = 0;
                    }
                    else
                    {
                        model.Contract = highlightsInfo.Contract;
                        model.Email = highlightsInfo.Contract;
                        model.ContractCompany = highlightsInfo.ContractCompany;
                        model.ContractCompanyEn = highlightsInfo.ContractCompanyEn;
                        model.LDdescribeCn = highlightsInfo.LDdescribeCn;
                        model.LDdescribeEn = highlightsInfo.LDdescribeEn;
                        model.LDimage = highlightsInfo.LDimage;
                        model.LDlogo = highlightsInfo.LDlogo;
                        model.LDnameCn = highlightsInfo.LDnameCn;
                        model.LDnameEn = highlightsInfo.LDnameEn;
                        model.Mobile = highlightsInfo.Mobile;
                        model.ShowWay = highlightsInfo.ShowWay;
                        model.Tel = highlightsInfo.Tel;
                        model.YJIntroduction = highlightsInfo.YJIntroduction;
                        model.YJname = highlightsInfo.YJname;
                        model.YJnameEn = highlightsInfo.YJnameEn;
                        model.YJPhoto = highlightsInfo.YJPhoto;
                        model.YJPosition = highlightsInfo.YJPosition;
                        model.YJPositionEn = highlightsInfo.YJPositionEn;
                        model.UpdatedAt = highlightsInfo.UpdatedAt;
                        model.Year = highlightsInfo.Year;
                        model.Website = highlightsInfo.Website;

                        count = await _context.SaveChangesAsync();
                        isSuccess = true;
                        msg = "修改成功";

                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据Id删除十大亮点信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> DeleteHighlightsInfoById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var gid = new Guid(id);
                    var model = await _context.HighlightsInfo.FirstOrDefaultAsync(x => x.Id == gid);
                    if (model == null)
                    {
                        msg = "数据库中没有id为" + id + "的实例可以删除！";
                        isSuccess = false;
                        count = 0;
                    }
                    else
                    {
                        _context.HighlightsInfo.Remove(model);
                        count = await _context.SaveChangesAsync();
                        if (count > 0)
                        {
                            msg = "删除成功";
                            isSuccess = true;
                        }
                        else
                        {
                            msg = "删除失败";
                            isSuccess = false;
                        }
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据Id获得十大亮点信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HighlightsInfo> GetHighlightsInfoById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    Guid gid = new Guid(id);
                    var item = await _context.HighlightsInfo
                            .FirstOrDefaultAsync(x => x.Id == gid);
                    return item;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据exbContractId获得十大亮点信息
        /// </summary>
        /// <param name="exbContractId"></param>
        /// <returns></returns>
        public async Task<HighlightsInfo> GetHighlightsInfoByExbContractId(string exbContractId)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var item = await _context.HighlightsInfo
                            .FirstOrDefaultAsync(x => x.ExbContractId == exbContractId);
                    return item;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }
        /// <summary>
        /// 根据条件查询十大亮点信息列表(带分页)
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<List<HighlightsInfo>> GetHighlightsInfoList(int pageindex, int pagesize, SearchModel searchModel)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    if (searchModel == null)
                    {
                        var list = await _context.HighlightsInfo
                                 .OrderByDescending(x => x.CreatedAt)
                                 .Skip(((pageindex - 1) * pagesize))
                                 .Take(pagesize)
                                 .ToListAsync();

                        return list;
                    }
                    else
                    {
                        var list = await _context.HighlightsInfo
                                .Where(x => (string.IsNullOrEmpty(searchModel.CompanyName) || x.ContractCompany.Contains(searchModel.CompanyName) || x.ContractCompanyEn.Contains(searchModel.CompanyName))
                                 && (string.IsNullOrEmpty(searchModel.OwnerId) || searchModel.OwnerId == x.OwnerId)
                                 && (string.IsNullOrEmpty(searchModel.Year) || x.Year == searchModel.Year)
                                 && (string.IsNullOrEmpty(searchModel.Website) || x.Website == searchModel.Website))
                                .OrderByDescending(x => x.CreatedAt)
                                .Skip(((pageindex - 1) * pagesize))
                                .Take(pagesize)
                                .ToListAsync();

                        return list;
                    }

                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }


        /// <summary>
        /// 根据条件查询十大亮点信息总数
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<int> GetHighlightsInfoListCount(SearchModel searchModel)
        {
            var total = 0;
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    if (searchModel != null)
                    {
                        var list = await _context.HighlightsInfo
                          .Where(x => (string.IsNullOrEmpty(searchModel.CompanyName) || x.ContractCompany.Contains(searchModel.CompanyName) || x.ContractCompanyEn.Contains(searchModel.CompanyName))
                          && (string.IsNullOrEmpty(searchModel.OwnerId) || searchModel.OwnerId == x.OwnerId)
                          && (string.IsNullOrEmpty(searchModel.Year) || x.Year == searchModel.Year)
                          && (string.IsNullOrEmpty(searchModel.Website) || x.Website == searchModel.Website))
                        .ToListAsync();
                        total = list.Count();
                    }
                    else
                    {
                        var list = await _context.HighlightsInfo.ToListAsync();
                        total = list.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
            return total;
        }

        #endregion

        #region Hotel(酒店)

        /// <summary>
        /// 创建酒店信息
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> CreateHotelInfo(Hotel hotel)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    await _context.Hotel.AddAsync(hotel);
                    count = await _context.SaveChangesAsync();

                    if (count > 0)
                    {
                        isSuccess = true;
                        msg = "创建成功";
                    }
                    else
                    {
                        isSuccess = false;
                        msg = "创建失败";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 修改酒店信息
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> UpdateHotelInfo(Hotel hotel)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var model = await _context.Hotel.FirstOrDefaultAsync(x => x.HotelId == hotel.HotelId);
                    if (model == null)
                    {
                        isSuccess = false;
                        msg = "当前实例不存在";
                        count = 0;
                    }
                    else
                    {
                        model.BankInfo = hotel.BankInfo;
                        model.BankInfoEn = hotel.BankInfoEn;
                        model.Country = hotel.Country;
                        model.HotelAddress = hotel.HotelAddress;
                        model.HotelAddressEn = hotel.HotelAddressEn;
                        model.HotelCode = hotel.HotelCode;
                        model.HotelEmail = hotel.HotelEmail;
                        model.HotelIntroduction = hotel.HotelIntroduction;
                        model.HotelIntroductionEn = hotel.HotelIntroductionEn;
                        model.HotelLevel = hotel.HotelLevel;
                        model.HotelName = hotel.HotelName;
                        model.HotelNameEn = hotel.HotelNameEn;
                        model.HotelTel = hotel.HotelTel;
                        model.KeyWord = hotel.KeyWord;
                        model.Remark = hotel.Remark;
                        model.RemarkEn = hotel.RemarkEn;
                        model.Sort = hotel.Sort;
                        model.UpdatedAt = hotel.UpdatedAt;

                        count = await _context.SaveChangesAsync();
                        isSuccess = true;
                        msg = "修改成功";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据HotelId删除酒店信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> DeleteHotelInfoById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var gid = new Guid(id);
                    var model = await _context.Hotel.Include(x => x.HotelRoomTypes).FirstOrDefaultAsync(x => x.HotelId == gid);
                    if (model == null)
                    {
                        msg = "数据库中没有id为" + id + "的实例可以删除！";
                        isSuccess = false;
                        count = 0;
                    }
                    else
                    {
                        if (model.HotelRoomTypes.Count > 0)
                        {
                            msg = "当前实例存在引用，无法删除";
                            isSuccess = false;
                            count = 0;
                        }
                        else
                        {
                            _context.Hotel.Remove(model);
                            count = await _context.SaveChangesAsync();
                            if (count > 0)
                            {
                                msg = "删除成功";
                                isSuccess = true;
                            }
                            else
                            {
                                msg = "删除失败";
                                isSuccess = false;
                            }
                        }

                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }


        /// <summary>
        /// 根据HotelId获得酒店信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Hotel> GetHotelById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    Guid gid = new Guid(id);
                    var item = await _context.Hotel
                            .FirstOrDefaultAsync(x => x.HotelId == gid);
                    return item;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 获得酒店信息列表
        /// </summary>
        /// <returns></returns>
        public async Task<List<Hotel>> GetHotelList()
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var list = await _context.Hotel.Include(x => x.HotelRoomTypes).OrderBy(x => x.HotelCode).ToListAsync();
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }
        #endregion


        #region HotelRoomType(酒店房间类型)

        /// <summary>
        /// 创建酒店房间类型
        /// </summary>
        /// <param name="hotelRoomType"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> CreateHotelRoomTypeInfo(HotelRoomType hotelRoomType)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    await _context.HotelRoomType.AddAsync(hotelRoomType);
                    count = await _context.SaveChangesAsync();
                    if (count > 0)
                    {
                        isSuccess = true;
                        msg = "创建成功";
                    }
                    else
                    {
                        isSuccess = false;
                        msg = "创建失败";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }


        /// <summary>
        /// 修改酒店房间类型信息
        /// </summary>
        /// <param name="hotelRoomType"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> UpdateHotelRoomTypeInfo(HotelRoomType hotelRoomType)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var model = await _context.HotelRoomType.FirstOrDefaultAsync(x => x.HotelRoomTypeId == hotelRoomType.HotelRoomTypeId);
                    if (model == null)
                    {
                        isSuccess = false;
                        msg = "当前实例不存在";
                        count = 0;
                    }
                    else
                    {
                        model.BedType = hotelRoomType.BedType;
                        model.BedTypeEn = hotelRoomType.BedTypeEn;
                        model.IsBreakfast = hotelRoomType.IsBreakfast;
                        model.IsNet = hotelRoomType.IsNet;
                        model.IsUsed = hotelRoomType.IsUsed;
                        model.MaxCount = hotelRoomType.MaxCount;
                        model.Price = hotelRoomType.Price;
                        model.Tax = hotelRoomType.Tax;
                        model.TypeName = hotelRoomType.TypeName;
                        model.TypeNameEn = hotelRoomType.TypeNameEn;
                        model.UpdatedAt = hotelRoomType.UpdatedAt;

                        count = await _context.SaveChangesAsync();
                        isSuccess = true;
                        msg = "修改成功";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据HptelRoomTypeId删除酒店房间类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> DeleteHotelRoomTypeById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var gid = new Guid(id);
                    var model = await _context.HotelRoomType.Include(x => x.HotelBookRecords).FirstOrDefaultAsync(x => x.HotelRoomTypeId == gid);
                    if (model == null)
                    {
                        msg = "数据库中没有id为" + id + "的实例可以删除！";
                        isSuccess = false;
                        count = 0;
                    }
                    else
                    {
                        if (model.HotelBookRecords.Count > 0)
                        {
                            msg = "当前实例存在引用,无法删除";
                            isSuccess = false;
                            count = 0;
                        }
                        else
                        {
                            _context.HotelRoomType.Remove(model);
                            count = await _context.SaveChangesAsync();
                            if (count > 0)
                            {
                                msg = "删除成功";
                                isSuccess = true;
                            }
                            else
                            {
                                msg = "删除失败";
                                isSuccess = false;
                            }
                        }

                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据HotelRoomTypeId获得酒店房间类型信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HotelRoomType> GetHotelRoomTypeInfoById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    Guid gid = new Guid(id);
                    var item = await _context.HotelRoomType
                            .FirstOrDefaultAsync(x => x.HotelRoomTypeId == gid);
                    return item;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据HotelId获得酒店房间集合
        /// </summary>
        /// <returns></returns>
        public async Task<List<HotelRoomType>> GetHolteRoomTypeListByHotelId(string hotelId)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var list = await _context.HotelRoomType
                        .Where(x => x.HotelId.ToString() == hotelId)
                        .OrderByDescending(x => x.TypeName)
                        .ToListAsync();
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }
        #endregion


        #region HotelBookRecord(酒店预定记录)

        /// <summary>
        /// 创建酒店预订信息
        /// </summary>
        /// <param name="hotelBookRecord"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> CreateHotelBookRecordInfo(HotelBookRecord hotelBookRecord)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    await _context.HotelBookRecord.AddAsync(hotelBookRecord);
                    count = await _context.SaveChangesAsync();
                    if (count > 0)
                    {
                        isSuccess = true;
                        msg = "创建成功";
                    }
                    else
                    {
                        isSuccess = false;
                        msg = "创建失败";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 修改酒店预订信息
        /// </summary>
        /// <param name="hotelBookRecord"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> UpdateHotelBookRecordInfo(HotelBookRecord hotelBookRecord)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var model = await _context.HotelBookRecord.FirstOrDefaultAsync(x => x.Id == hotelBookRecord.Id);
                    if (model == null)
                    {
                        isSuccess = false;
                        msg = "当前实例不存在";
                        count = 0;
                    }
                    else
                    {
                        model.ArriveFlight = hotelBookRecord.ArriveFlight;
                        model.CardDate = hotelBookRecord.CardDate;
                        model.CardNumber = hotelBookRecord.CardNumber;
                        model.CardPerson = hotelBookRecord.CardPerson;
                        model.CardType = hotelBookRecord.CardType;
                        model.CheckInTime = hotelBookRecord.CheckInTime;
                        model.CheckOutTime = hotelBookRecord.CheckOutTime;
                        model.Days = hotelBookRecord.Days;
                        model.IsSmoke = hotelBookRecord.IsSmoke;
                        model.LeaveFlight = hotelBookRecord.LeaveFlight;
                        model.LinkManBirth = hotelBookRecord.LinkManBirth;
                        model.LinkManCity = hotelBookRecord.LinkManCity;
                        model.LinkManCompany = hotelBookRecord.LinkManCompany;
                        model.LinkManCountry = hotelBookRecord.LinkManCountry;
                        model.LinkManEmail = hotelBookRecord.LinkManEmail;
                        model.LinkManEmail2 = hotelBookRecord.LinkManEmail2;
                        model.LinkManFax = hotelBookRecord.LinkManFax;
                        model.LinkManFirstName = hotelBookRecord.LinkManFirstName;
                        model.LinkManIdCardNumber = hotelBookRecord.LinkManIdCardNumber;
                        model.LinkManIdCardType = hotelBookRecord.LinkManIdCardType;
                        model.LinkManLastName = hotelBookRecord.LinkManLastName;
                        model.LinkManMobile = hotelBookRecord.LinkManMobile;
                        model.LinkManTel = hotelBookRecord.LinkManTel;
                        model.LinkManTitle = hotelBookRecord.LinkManTitle;
                        model.OtherCompany = hotelBookRecord.OtherCompany;
                        model.OtherEmail = hotelBookRecord.OtherEmail;
                        model.OtherMobile = hotelBookRecord.OtherMobile;
                        model.OtherName = hotelBookRecord.OtherName;
                        model.OtherTitle = hotelBookRecord.OtherTitle;
                        model.Payer = hotelBookRecord.Payer;
                        model.PayType = hotelBookRecord.PayType;
                        model.PriceCount = hotelBookRecord.PriceCount;
                        model.Remark = hotelBookRecord.Remark;
                        model.UpdatedAt = hotelBookRecord.UpdatedAt;

                        count = await _context.SaveChangesAsync();
                        isSuccess = true;
                        msg = "修改成功";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据Id删除酒店预订记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> DeleteHotelBookRecordInfoById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var gid = new Guid(id);
                    var model = await _context.HotelBookRecord.FirstOrDefaultAsync(x => x.Id == gid);
                    if (model == null)
                    {
                        msg = "数据库中没有id为" + id + "的实例可以删除！";
                        isSuccess = false;
                        count = 0;
                    }
                    else
                    {
                        _context.HotelBookRecord.Remove(model);
                        count = await _context.SaveChangesAsync();
                        if (count > 0)
                        {
                            msg = "删除成功";
                            isSuccess = true;
                        }
                        else
                        {
                            msg = "删除失败";
                            isSuccess = false;
                        }
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        /// <summary>
        /// 根据MemberId获得酒店预订记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<List<HotelBookRecord>> GetHotelBookRecordByMemberId(string memberId)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var list = await _context.HotelBookRecord.Include(x => x.HotelItem).Include(x => x.HotelRoomTypeItem)
                        .Where(x => x.MemberId == memberId).ToListAsync();
                    return list;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }


        /// <summary>
        /// 根据Id取消酒店预订
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> CancelHotelBookRecordById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var gid = new Guid(id);
                    var model = await _context.HotelBookRecord.FirstOrDefaultAsync(x => x.Id == gid);
                    if (model == null)
                    {
                        msg = "当前实例不存在";
                        count = 0;
                        isSuccess = false;
                    }
                    else
                    {
                        model.IsCanceled = true;
                        model.UpdatedAt = DateTime.UtcNow.ToUniversalTime();

                        count = await _context.SaveChangesAsync();
                        isSuccess = true;
                        msg = "修改成功";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }


        /// <summary>
        /// 根据Id获得酒店预订记录
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<HotelBookRecord> GetHotelBookRecordById(string id)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    Guid gid = new Guid(id);
                    var item = await _context.HotelBookRecord
                            .FirstOrDefaultAsync(x => x.Id == gid);
                    return item;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据条件查询酒店预订记录列表(带分页)
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<List<HotelBookRecord>> GetHotelBookRecordList(int pageindex, int pagesize, SearchModel searchModel)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    if (searchModel == null)
                    {
                        var list = await _context.HotelBookRecord.Include(x => x.HotelItem).Include(x => x.HotelRoomTypeItem)
                                 .OrderByDescending(x => x.CreatedAt)
                                 .Skip(((pageindex - 1) * pagesize))
                                 .Take(pagesize)
                                 .ToListAsync();

                        return list;
                    }
                    else
                    {
                        var list = await _context.HotelBookRecord
                                .Where(x => (string.IsNullOrEmpty(searchModel.HotelId) || searchModel.HotelId == x.HotelId.ToString())
                                 && (string.IsNullOrEmpty(searchModel.HotelRoomTypeId) || searchModel.HotelRoomTypeId == x.HotelRoomTypeId.ToString())
                                 && (string.IsNullOrEmpty(searchModel.IsChecked) || DataHelper.GetInt32(searchModel.IsChecked) == x.IsChecked)
                                 && (string.IsNullOrEmpty(searchModel.IsCanceled) || DataHelper.GetBool(searchModel.IsCanceled) == x.IsCanceled)
                                 && (string.IsNullOrEmpty(searchModel.Begin_date) || x.BookTime >= Convert.ToDateTime(searchModel.Begin_date))
                                 && (string.IsNullOrEmpty(searchModel.End_date) || x.BookTime <= Convert.ToDateTime(searchModel.End_date))
                                 && (string.IsNullOrEmpty(searchModel.IsWebsite) || DataHelper.GetBool(searchModel.IsWebsite) == x.IsWebsite)
                                 && (string.IsNullOrEmpty(searchModel.MemberId) || x.MemberId == searchModel.MemberId))
                                 .Include(x => x.HotelItem).Include(x => x.HotelRoomTypeItem)
                                 .OrderByDescending(x => x.CreatedAt)
                                 .Skip(((pageindex - 1) * pagesize))
                                 .Take(pagesize)
                                 .ToListAsync();

                        return list;
                    }

                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据条件查询酒店预订记录总数
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<int> GetHotelBookRecordListCount(SearchModel searchModel)
        {
            var total = 0;
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    if (searchModel != null)
                    {
                        var list = await _context.HotelBookRecord
                         .Where(x => (string.IsNullOrEmpty(searchModel.HotelId) || searchModel.HotelId == x.HotelId.ToString())
                       && (string.IsNullOrEmpty(searchModel.HotelRoomTypeId) || searchModel.HotelRoomTypeId == x.HotelRoomTypeId.ToString())
                       && (string.IsNullOrEmpty(searchModel.IsChecked) || DataHelper.GetInt32(searchModel.IsChecked) == x.IsChecked)
                       && (string.IsNullOrEmpty(searchModel.IsCanceled) || DataHelper.GetBool(searchModel.IsCanceled) == x.IsCanceled)
                       && (string.IsNullOrEmpty(searchModel.Begin_date) || x.BookTime >= Convert.ToDateTime(searchModel.Begin_date))
                       && (string.IsNullOrEmpty(searchModel.End_date) || x.BookTime <= Convert.ToDateTime(searchModel.End_date))
                       && (string.IsNullOrEmpty(searchModel.IsWebsite) || DataHelper.GetBool(searchModel.IsWebsite) == x.IsWebsite)
                       && (string.IsNullOrEmpty(searchModel.MemberId) || x.MemberId == searchModel.MemberId))
                        .ToListAsync();
                        total = list.Count();
                    }
                    else
                    {
                        var list = await _context.HotelBookRecord.ToListAsync();
                        total = list.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
            return total;
        }

        /// <summary>
        /// 根据条件查询酒店订单列表(以订单人为单位的分组查询结果,带分页)
        /// </summary>
        /// <param name="pageindex"></param>
        /// <param name="pagesize"></param>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<List<OrderPerson>> GetHotelOrderList(int pageindex, int pagesize, SearchModel searchModel)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    if (searchModel == null)
                    {
                        var list = await _context.HotelBookRecord
                                 .OrderByDescending(x => x.CreatedAt)
                                 .GroupBy(x => new { x.MemberId, x.MemberCompany, x.MemberEmail, x.MemberName, x.MemberCompanyEn })
                                 .Select(g => new OrderPerson
                                 {
                                     MemberId = g.Key.MemberId,
                                     MemberCompany = g.Key.MemberCompany,
                                     MemberEmail = g.Key.MemberEmail,
                                     MemberName = g.Key.MemberName,
                                     MemberCompanyEn = g.Key.MemberCompanyEn

                                 }).OrderByDescending(x => x.MemberCompany)
                                 .Skip(((pageindex - 1) * pagesize))
                                 .Take(pagesize)
                                 .ToListAsync();
                        return list;

                    }
                    else
                    {
                        var list = await _context.HotelBookRecord
                                 .OrderByDescending(x => x.CreatedAt)
                                 .GroupBy(x => new { x.MemberId, x.MemberCompany, x.MemberEmail, x.MemberName, x.MemberCompanyEn })
                                 .Select(g => new OrderPerson
                                 {
                                     MemberId = g.Key.MemberId,
                                     MemberCompany = g.Key.MemberCompany,
                                     MemberEmail = g.Key.MemberEmail,
                                     MemberName = g.Key.MemberName,
                                     MemberCompanyEn = g.Key.MemberCompanyEn
                                 }).OrderByDescending(x => x.MemberCompany)
                                 .Where(x => (string.IsNullOrEmpty(searchModel.Email) || x.MemberEmail.Contains(searchModel.Email))
                                 && (string.IsNullOrEmpty(searchModel.CompanyName) || x.MemberCompany.Contains(searchModel.CompanyName) || x.MemberCompanyEn.Contains(searchModel.CompanyName)))
                                 .Skip(((pageindex - 1) * pagesize))
                                 .Take(pagesize)
                                 .ToListAsync();

                        return list;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
        }

        /// <summary>
        /// 根据条件查询酒店订单列表(以订单人为单位的分组查询结果)记录总数
        /// </summary>
        /// <param name="searchModel"></param>
        /// <returns></returns>
        public async Task<int> GetHotelOrderListCount(SearchModel searchModel)
        {
            var total = 0;
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    if (searchModel != null)
                    {
                        var list = await _context.HotelBookRecord
                               .GroupBy(x => new { x.MemberId, x.MemberCompany, x.MemberEmail, x.MemberName, x.MemberCompanyEn })
                               .Select(g => new OrderPerson
                               {
                                   MemberId = g.Key.MemberId,
                                   MemberCompany = g.Key.MemberCompany,
                                   MemberEmail = g.Key.MemberEmail,
                                   MemberName = g.Key.MemberName,
                                   MemberCompanyEn = g.Key.MemberCompanyEn
                               }).OrderByDescending(x => x.MemberCompany)
                               .Where(x => (string.IsNullOrEmpty(searchModel.Email) || x.MemberEmail.Contains(searchModel.Email))
                               && (string.IsNullOrEmpty(searchModel.CompanyName) || x.MemberCompany.Contains(searchModel.CompanyName) || x.MemberCompanyEn.Contains(searchModel.CompanyName)))
                               .ToListAsync();
                        total = list.Count();
                    }
                    else
                    {
                        var list = await _context.HotelBookRecord
                               .GroupBy(x => new { x.MemberId, x.MemberCompany, x.MemberEmail, x.MemberName, x.MemberCompanyEn })
                               .Select(g => new OrderPerson
                               {
                                   MemberId = g.Key.MemberId,
                                   MemberCompany = g.Key.MemberCompany,
                                   MemberEmail = g.Key.MemberEmail,
                                   MemberName = g.Key.MemberName,
                                   MemberCompanyEn = g.Key.MemberCompanyEn
                               }).ToListAsync();

                        total = list.Count;
                    }
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                throw new Exception("异常", ex);
            }
            return total;
        }

        /// <summary>
        /// 更新HotelBookRecord表中IsChecked字段
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<ModifyReplyModel> UpdateIsChecked(UpdateIsCheckedModel model)
        {
            try
            {
                using (var _context = new MyContext(_options.Options))
                {
                    var modified_model = await _context.HotelBookRecord.FirstOrDefaultAsync(x => x.Id == model.Id);
                    if (modified_model == null)
                    {
                        msg = "当前实例不存在";
                        count = 0;
                        isSuccess = false;
                    }
                    else
                    {
                        #region 修改
                        modified_model.IsChecked = model.IsChecked;
                        #endregion
                        count = await _context.SaveChangesAsync();
                        isSuccess = true;
                        msg = "修改成功";
                    }
                    return GetModifyReply(isSuccess, msg, count);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Error(this, ex);
                return GetModifyReply(isSuccess, ex.Message, count);
            }
        }

        #endregion
        /// <summary>
        /// 返回ModifyReplyModel对象
        /// </summary>
        /// <param name="success"></param>
        /// <param name="msg"></param>
        /// <param name="modified_count"></param>
        /// <returns></returns>
        private ModifyReplyModel GetModifyReply(bool success, string msg, int modified_count)
        {
            return new ModifyReplyModel() { success = success, modifiedcount = modified_count, msg = msg };
        }
    }
}
